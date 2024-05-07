using Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class TextExtractor : ITextExtractor
    {
        public string ExtractText(string file)
        {
            string text = File.ReadAllText(file).Replace(Environment.NewLine, " ");
            if(text is null)
            {
                Console.WriteLine($" Пустой файл: {file}");
                return null;
            }
            else
            {
                text = text.ToLower();
            }
            return text;
        }
    }
}
