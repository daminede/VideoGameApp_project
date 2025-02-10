using Microsoft.Extensions.Options;
using VideoGameApp.Models;  // Ensure this is included

namespace VideoGameApp.Services
{
    public class MyService
    {
        private readonly VideoGameAppSettings _settings;

        public MyService(IOptions<VideoGameAppSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GetApiKey()
        {
            return _settings.ApiKey;
        }
    }
}
