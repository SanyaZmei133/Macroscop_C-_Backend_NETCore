using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static PathValidator validator = new PathValidator();
        static TextExtractor textExtractor = new TextExtractor();
        static PathReader reader = new PathReader(validator);

        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.Title = "Client";
            Console.WriteLine("Нажминете любую клавишу для продолжения");
            Console.ReadLine();
            string path = reader.GetPath();
            var files = Directory.GetFiles(path, "*.txt");
            if (files is null)
            {
                Console.WriteLine("Не найдено текстовых файлов");
            }
            else
            {
                foreach (var file in files)
                {
                    StringContent content = new StringContent(textExtractor.ExtractText(file));
                    if (content is null)
                    {
                        continue;
                    }
                        
                    using var response = await client.PostAsync("http://localhost:5155/polindrome", content);
                    string responseText = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseText);
                }
            }
            
            Console.ReadLine() ;
        }
    }
}
