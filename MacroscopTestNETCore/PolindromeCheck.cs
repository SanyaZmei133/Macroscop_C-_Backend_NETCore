using MacroscopTestNETCore.Interfaces;

namespace MacroscopTestNETCore
{
    public class PolindromeCheck : IPolindromeCheck
    {
        public bool IsPolindrome(string[] words)
        {
            foreach (string word in words)
            {
                for (int i = 0, j = word.Length - 1; i < j; i++, j--)
                {
                    if (word[i] != word[j])
                        return false;
                }
            }
            return true;
        }
    }
}
