namespace MacroscopTestNETCore.Interfaces
{
    public interface IPolindomeRepository
    {
        public string[] GetWords(string text);
        public string CheckPolindrome(string[] words);
    }
}
