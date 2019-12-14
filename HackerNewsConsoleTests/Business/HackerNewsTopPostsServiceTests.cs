using HackerNewsConsole.DataServices;
using HackerNewsConsole.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var HNItem1 = GetValidStory(1, "Item 1");
            var HNItem2 = GetValidStory(2, "Item 2");
            var HNItem3 = GetValidStory(3, "Item 3");

            ItemDataServiceMock.Setup(s => s.GetItem(item1)).Returns(Task.FromResult(HNItem1));
            ItemDataServiceMock.Setup(s => s.GetItem(item2)).Returns(Task.FromResult(HNItem2));
            ItemDataServiceMock.Setup(s => s.GetItem(item3)).Returns(Task.FromResult(HNItem3));
            TopStoriesDataServiceMock.Setup(s => s.GetTopStories()).Returns(Task.FromResult(new List<int>() { item1, item2, item3 }.AsEnumerable()));

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
            var HNItem1 = GetValidStory(1, "Item 1");
            var HNItem2 = GetValidStory(2, "Item 2");

            ItemDataServiceMock.Setup(s => s.GetItem(item1)).Returns(Task.FromResult(HNItem1));
            ItemDataServiceMock.Setup(s => s.GetItem(item2)).Returns(Task.FromResult(HNItem2));
            TopStoriesDataServiceMock.Setup(s => s.GetTopStories()).Returns(Task.FromResult(new List<int>() { item1, item2, 3, 4, 5, 6, 7, 8, 9, 0 }.AsEnumerable()));

            var result = HackerNewsTopPostsServiceUT.GetTopItems(2);

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(s => s.Title == HNItem1.Title));
            Assert.AreEqual(1, result.Count(s => s.Title == HNItem2.Title));
        }

        [TestInitialize]
        public void SetupService()
        {
            TopStoriesDataServiceMock = new Mock<ITopStoriesDataService>();
            ItemDataServiceMock = new Mock<IItemDataService>();

            HackerNewsTopPostsServiceUT = new HackerNewsTopPostsService(TopStoriesDataServiceMock.Object, ItemDataServiceMock.Object);
        }

        private HNItem GetValidStory(int id, string title) =>
            new HNItem
            {
                Id = id,
                Title = title,
                Kids = new List<int>() { 1, 2 },
                Score = 1,
                Url = "https://news.ycombinator.com/",
                Type = HNItemTypes.Story
            };
    }
}