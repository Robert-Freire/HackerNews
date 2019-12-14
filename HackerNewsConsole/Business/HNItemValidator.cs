using HackerNewsConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerNewsConsole.Business
{
    public static class HNItemValidator
    {
        public static bool IsValidStory(this HNItem HNItem)
        {
            if (HNItemTypes.Story != HNItem.Type) return false;
            if (string.IsNullOrEmpty(HNItem.Title) || HNItem.Title.Length > 256) return false;
            if (!Uri.IsWellFormedUriString(HNItem.Url, UriKind.Absolute)) return false;
            if (HNItem.Score <= 0) return false;
            if (HNItem.Kids == null) return false;
            if (HNItem.Kids.Count() == 0) return false;

            return true;
        }
    }
}
