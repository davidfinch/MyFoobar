using MyFoobar.Web.Interfaces;
using System.ServiceModel.Syndication;
using System.Xml;

namespace MyFoobar.Web.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<List<string>> GetForecast(string url)
        {
            var threeDayFoecast = new List<string>();
            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create(url, new XmlReaderSettings { Async = true }))
                {
                    feed = await Task.Run(() => SyndicationFeed.Load(reader));

                }
            }
            catch { } // TODO: Deal with unavailable resource.

            if (feed != null)
            {
                foreach (var element in feed.Items)
                {
                    threeDayFoecast.Add(element.Title.Text);
                }
            }

            return threeDayFoecast;
        }
    }
}
        
