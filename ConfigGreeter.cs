using Microsoft.Extensions.Configuration;
namespace DotNetCoreFunda
{
    public class ConfigGreeter : IGreeter
    {
        private IConfiguration _configuration;
        public ConfigGreeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetMessage()
        {
            return _configuration["Greetings"];
        }
    }
}