using MacroscopTestNETCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace MacroscopTestNETCore.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class PolindromeController : ControllerBase
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);
        private readonly IPolindomeRepository _polindromeRepository;

        public PolindromeController(IPolindomeRepository polindomeRepository)
        {
            _polindromeRepository = polindomeRepository;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string text = await reader.ReadToEndAsync();

            var tasks = new List<Task>();
            string response = " ";

            await semaphoreSlim.WaitAsync();
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    string[] words = _polindromeRepository.GetWords(text);
                    response = _polindromeRepository.CheckPolindrome(words);
                }
                finally
                {
                    semaphoreSlim.Release();
                }
            }));
            Task.WaitAll(tasks.ToArray());
            Thread.Sleep(1000);
            return response;
        }
    }
}
