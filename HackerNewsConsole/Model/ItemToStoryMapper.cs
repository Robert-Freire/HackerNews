using HackerNewsConsole.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerNewsConsole.Model
{
    public static class ItemToStoryMapper
    {
        public static Story Map(this HNItem HNItem, int rank)
        {
            if (HNItem == null)
                return null;
            if (HNItem.Type != "story")
                throw new InvalidHNItemToStoryException(HNItem, $"Invalid type {HNItem.Type} for item {HNItem.Id}");
            else
                return new Story()
                {
                    Title = HNItem.Title,
                    Uri = HNItem.Url,
                    Author = HNItem.By,
                    Points = HNItem.Score,
                    Comments = HNItem.Kids == null? 0: HNItem.Kids.Count(),
                    Rank = rank
                };
        }
    }
}
