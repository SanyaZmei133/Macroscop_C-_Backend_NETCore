using MacroscopTestNETCore.Interfaces;

namespace MacroscopTestNETCore
{
    public class StringSeparator : IStringSeparator
    {
        public string[] GetWords(string text)
        {
            string[] words = text.Split(['.', ',', ' ', ';']);
            return words;
        }
    }
}
