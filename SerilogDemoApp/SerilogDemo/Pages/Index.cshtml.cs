using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the Index Page");
            try
            {
                //throw new Exception("This is our demo exception");
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56)
                    {
                        throw new Exception("This is our demo exception");
                    }

                    _logger.LogInformation("The value of i is {iVariable}", i);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "We caught this expception in the Index Get call");
            }
        }
    }
}