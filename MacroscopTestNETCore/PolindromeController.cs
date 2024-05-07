using MacroscopTestNETCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace MacroscopTestNETCore
{
    [Route("[controller]")]
    [ApiController]
    public class PolindromeController : ControllerBase
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);
        private readonly IPolindromeCheck _polindrome;
        private readonly IStringSeparator _separator;

        public PolindromeController(IPolindromeCheck polindrome, IStringSeparator separator)
        {
            _polindrome = polindrome;
            _separator = separator;
        }

        [HttpPost]
        public async Task <string> Post() 
        {

            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string text = await reader.ReadToEndAsync();

            string[] words = _separator.GetWords(text);

            string response = " ";

            var tasks = new List<Task>();

            await semaphoreSlim.WaitAsync();
            Thread.Sleep(1000);
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    if (_polindrome.IsPolindrome(words))
                    {
                        response = "файл является полиндромом";
                    }
                    else
                    {
                        response = "файл не является полиндромом";
                    }
                }
                finally
                {
                    semaphoreSlim.Release();
                }
                
            }));
            Task.WaitAll(tasks.ToArray());
            return response;
        }
    }
}
