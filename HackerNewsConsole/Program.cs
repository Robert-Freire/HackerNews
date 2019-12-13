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
        static void Main(string[] args)
        {
            SetupDI();
            var hackerNewsTopPostsService = serviceProvider.GetService<IHackerNewsTopPostsService>();

            var result = hackerNewsTopPostsService.GetTopItems(2);
            Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
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
