// ***********************************************************************
// Assembly         : HackerNewsConsole
// Author           : robert
// Created          : 12-13-2019
//
// Last Modified By : rober
// Last Modified On : 12-13-2019
// ***********************************************************************
// <copyright file="Program.cs" company="HackerNewsConsole">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using HackerNewsConsole.Business;
using HackerNewsConsole.DataServices;
using HackerNewsConsole.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;

namespace HackerNewsConsole
{

    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The DI service provider
        /// </summary>
        private static ServiceProvider serviceProvider;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static int Main(string[] args)
        {
            var callError = CheckParameters(args, out int numItems);
            if (callError != "")
            {
                Console.WriteLine(callError);
                return 1;
            }
            try
            {
                SetupDI();
                var hackerNewsTopPostsService = serviceProvider.GetService<IHackerNewsTopPostsService>();
                foreach (var result in hackerNewsTopPostsService.GetTopItems(numItems))
                {
                    Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                }
            } 
            catch (InvalidHNItemToStoryException e)
            {
                Console.WriteLine($"HackerNews: Upps, Hachernews 1.0 could not cope with the item {e.HNItem.Id} you will have to wait to v 2.0");
            }
            catch (Exception)
            {
                Console.WriteLine("HackerNews: Upps! Houston, we have a problem");
            }
 
            return 0;
        }

        /// <summary>Checks the parameters.</summary>
        /// <param name="args">The arguments.</param>
        /// <param name="numItems">Output parameter. The number items.</param>
        /// <returns></returns>
        private static String CheckParameters(string[] args, out int numItems)
        {
            numItems = 0;
            if ((args.Length != 2) || (args[1].ToLower() == "posts"))
            {
                return "hackernews: Bad call mate. Try again with format 'hackernews --posts n' ";
            }
            if (!int.TryParse(args[1], out numItems))
            {
                return "hackernews: Bad call mate. Try again replacing n with the number of posts that you want 'hackernews --posts n' ";
            }
            if (numItems < 0)
            {
                return $"hackernews: Hey! Don't play dumb with me. What means that you want {numItems} stories?";
            }
            if (numItems == 0)
            {
                return $"hackernews: Great!!! Free time. Thanks mate.";
            }
            if (numItems > 100)
            {
                return "hackernews: Don't be greedy mate. With a hundred news from HackerNews will be enough ";
            }
            return "";
        }

        /// <summary>
        /// Setups the Dependecy Injection.
        /// </summary>
        private static void SetupDI()
        {
            var configuration = getConfiguration();

            var topStoriesUrl = configuration.GetSection("HackerNewsAPI:Server").Value + configuration.GetSection("HackerNewsAPI:EndPoints:TopStories").Value;
            var getItemUrl = configuration.GetSection("HackerNewsAPI:Server").Value + configuration.GetSection("HackerNewsAPI:EndPoints:GetItem").Value;

            serviceProvider = new ServiceCollection()
                .AddSingleton<ITopStoriesDataService>(s => new TopStoriesDataService(topStoriesUrl))
                .AddSingleton<IItemDataService>(s => new ItemDataService(getItemUrl))
                .AddSingleton<IHackerNewsTopPostsService, HackerNewsTopPostsService>()
                .BuildServiceProvider();

        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>IConfiguration.</returns>
        private static IConfiguration getConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
