﻿using HackerNewsConsole.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerNewsConsole.Model.Tests
{
    [TestClass()]
    public class ItemToStoryMapperTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidHNItemToStoryException))]
        public void GivenThatTheItemIsNotStory_WhenIsMappedToStories_ThenAExceptionIsLaunch()
        {
            var NHItemUT = new HNItem()
            {
                Type = "comment"
            };

            var story = NHItemUT.Map(1);
        }

        [TestMethod()]

        public void GivenThatTheItemIsStory_WhenIsMappedToStories_ThenANewStoryObjectIsCreated()
        {
            var NHItemUT = new HNItem()
            {
                Type = HNItemTypes.Story,
                Title = "Some title",
                By = "author",
                Score = 33
            };
            var rank = 6;

            var story = NHItemUT.Map(rank);

            Assert.AreEqual(NHItemUT.Title, story.Title);
            Assert.AreEqual(NHItemUT.By, story.Author);
            Assert.AreEqual(rank, story.Rank);
            Assert.AreEqual(NHItemUT.Score, story.Points);
        }
    }
}