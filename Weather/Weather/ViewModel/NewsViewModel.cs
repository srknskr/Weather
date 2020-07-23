using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Weather.Connection;
using Weather.Model;
using Weather.Services;

namespace Weather.ViewModel
{
   public class NewsViewModel : INotifyPropertyChanged
    {
        private static Database database = null;

        private IList<News> newsList;
        public IList<News> NewsList
        {
            get
            {
                if (newsList == null)
                    newsList = new ObservableCollection<News>();
                return newsList;
            }
            set
            {
                newsList = value;
                OnPropertyChanged();
            }
        }
        private List<Places> _places;

        public List<Places> Places
        {
            get
            {
                return _places;
            }

            set
            {
                _places = value;
                OnPropertyChanged();
            }
        }
        private List<Article> articleList { get; set; }
        public List<Article> ArticleList
        {
            get
            {
                return articleList;
            }

            set
            {
                if (value != articleList)
                {
                    articleList = value;
                    OnPropertyChanged();
                }
            }
        }
        private static Database GetConnection()
        {
            if (database == null)
                database = new Database();
            return database;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NewsViewModel()
        {
            Places = GetConnection().GetFirst();
            Task.Run(APIAsync);
        }
        private async Task APIAsync()
        {
            var news = await NewsAPI.GetNewsAsync(Places[0].CityName + " Hava Durumu");
            List<Article> articleList = new List<Article>();
            for (int i = 0; i < news.articles.Count; i++)
            {
                articleList.Add(new Article
                {
                    title= news.articles[i].title,
                    description=news.articles[i].description,
                    urlToImage=news.articles[i].urlToImage
                }
                );
            }


            ArticleList = articleList;
        }
    }
}
