using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Model
{
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }

    public class News
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public IList<Article> articles { get; set; }
    }
}
