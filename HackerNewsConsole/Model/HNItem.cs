using System.Collections.Generic;

namespace HackerNewsConsole.Model
{
    /// <summary>
    /// Class HNItem.
    /// </summary>
    public class HNItem
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public string By { get; set; }
        
        /// <summary>
        /// Gets or sets the descendants.
        /// </summary>
        /// <value>The descendants.</value>
        public int Descendants { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the kids.
        /// </summary>
        /// <value>The kids.</value>
        public IEnumerable<int> Kids { get; set; }
        
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        public int Score { get; set; }
        
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public long Time { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }
        
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
    }
}
