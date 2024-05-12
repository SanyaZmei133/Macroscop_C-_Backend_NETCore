using MacroscopTestNETCore.Interfaces;

namespace MacroscopTestNETCore.Repositories
{
    public class PolindromeRepository : IPolindomeRepository
    {
        private readonly IPolindromeCheck _polindromeCheck;
        private readonly IStringSeparator _stringSeparator;

        public PolindromeRepository(IPolindromeCheck polindromeCheck, IStringSeparator stringSeparator)
        {
            _polindromeCheck = polindromeCheck;
            _stringSeparator = stringSeparator;
        }

        public string CheckPolindrome(string[] words)
        {
            if (_polindromeCheck.IsPolindrome(words))
            {
                return "файл является полиндромом";
            }
            else
            {
                return "файл не является полиндромом";
            }
        }

        public string[] GetWords(string text)
        {
            return _stringSeparator.GetWords(text);
        }
    }
}
