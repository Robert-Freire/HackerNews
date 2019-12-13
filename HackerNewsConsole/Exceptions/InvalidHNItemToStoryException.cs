using HackerNewsConsole.Model;
using System;


namespace HackerNewsConsole.Exceptions
{
    public class InvalidHNItemToStoryException : Exception
    {
        public HNItem HNItem { get; set; }

        public InvalidHNItemToStoryException(HNItem HNItem) : base()
        {
            this.HNItem = HNItem;
        }

        public InvalidHNItemToStoryException(HNItem HNItem, string message) : base(message)
        {
            this.HNItem = HNItem;
        }
    }
}
