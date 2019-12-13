using Microsoft.VisualStudio.TestTools.UnitTesting;
using HackerNewsConsole.Business;
using System;
using System.Collections.Generic;
using System.Text;
using HackerNewsConsole.DataServices;
using Moq;
using System.Threading.Tasks;
using HackerNewsConsole.Model;
using System.Linq;

namespace HackerNewsConsole.Business.Tests
{
    [TestClass()]
    public class HackerNewsTopPostsServiceTests
    {
        private IHackerNewsTopPostsService HackerNewsTopPostsServiceUT;
        private Mock<ITopStoriesDataService> TopStoriesDataServiceMock;
        private Mock<IItemDataService> ItemDataServiceMock;


        [TestMethod()]
        public void GivenThatThereAreNo5ews_WhenIRequestTheTop5_ThenEmptyListIsReturned()
        {
            ItemDataServiceMock.Setup(s => s.GetItem(It.IsAny<int>())).Returns(Task.FromResult(new HNItem()));
            TopStoriesDataServiceMock.Setup(s => s.GetTopStories()).Returns(Task.FromResult(new List<int>().AsEnumerable()));

            var result = HackerNewsTopPostsServiceUT.GetTopItems(5);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod()]
        public void GivenThatThereAre3News_WhenIRequestTheTop3_ThenListWithThreeItemsIsReturned()
        {
            var item1 = 1;
            var item2 = 2;
            var item3 = 3;
            var HNItem1 = new HNItem { Id = 1, Title = "Item 1", Type = "story" };
            var HNItem2 = new HNItem { Id = 2, Title = "Item 2", Type = "story" };
            var HNItem3 = new HNItem { Id = 3, Title = "Item 3", Type = "story" };

            ItemDataServiceMock.Setup(s => s.GetItem(item1)).Returns(Task.FromResult(HNItem1));
            ItemDataServiceMock.Setup(s => s.GetItem(item2)).Returns(Task.FromResult(HNItem2));
            ItemDataServiceMock.Setup(s => s.GetItem(item3)).Returns(Task.FromResult(HNItem3));
            TopStoriesDataServiceMock.Setup(s => s.GetTopStories()).Returns(Task.FromResult(new List<int>() { item1, item2, item3}.AsEnumerable()));

            var result = HackerNewsTopPostsServiceUT.GetTopItems(3);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(1, result.Count(s => s.Title == HNItem1.Title));
            Assert.AreEqual(1, result.Count(s => s.Title == HNItem2.Title));
            Assert.AreEqual(1, result.Count(s => s.Title == HNItem3.Title));
        }

        [TestMethod()]
        public void GivenThatThereAre10News_WhenIRequestTheTop2_ThenListWithTwoItemsIsReturned()
        {
            var item1 = 1;
            var item2 = 2;
            var HNItem1 = new HNItem { Id = 1, Title = "Item 1", Type = "story" };
            var HNItem2 = new HNItem { Id = 2, Title = "Item 2", Type = "story" };

            ItemDataServiceMock.Setup(s => s.GetItem(item1)).Returns(Task.FromResult(HNItem1));
            ItemDataServiceMock.Setup(s => s.GetItem(item2)).Returns(Task.FromResult(HNItem2));
            TopStoriesDataServiceMock.Setup(s => s.GetTopStories()).Returns(Task.FromResult(new List<int>() { item1, item2, 3, 4, 5, 6, 7, 8, 9, 0 }.AsEnumerable()));

            var result = HackerNewsTopPostsServiceUT.GetTopItems(2);

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(s=> s.Title == HNItem1.Title));
            Assert.AreEqual(1, result.Count(s => s.Title == HNItem2.Title));
        }

        [TestInitialize]
        public void SetupService()
        {
            TopStoriesDataServiceMock = new Mock<ITopStoriesDataService>();
            ItemDataServiceMock = new Mock<IItemDataService>();

            HackerNewsTopPostsServiceUT = new HackerNewsTopPostsService(TopStoriesDataServiceMock.Object, ItemDataServiceMock.Object);
        }
    }
}