namespace MyFoobar.Web.Interfaces
{
    public interface IWeatherService
    {
        public Task<List<string>> GetForecast(string url);
    }
}
