using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private const string ApiKeyHeaderName = "X-Api-Key";
        private const string ValidApiKey = "YOUR_API_KEY"; // 請替換為你的 API Key
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            ResultMessage result = new ResultMessage();
            string apiKey = "";
            if (!HttpContext.Request.Headers.ContainsKey(ApiKeyHeaderName))
            {
                result.code = 500;
                result.message = "HeaderName Not Works...";
                return new JsonResult(result);
            }
            else
            {
                apiKey = HttpContext.Request.Headers[ApiKeyHeaderName];
            }

            if (apiKey != ValidApiKey)
            {
                result.code = 500;
                result.message = "ApiKey Not Works...";
                return new JsonResult(result);
            }
            // do db using dapper 

            result.code = 200;
            result.message = "OK";
            return new JsonResult(result);
        }
    }
}
