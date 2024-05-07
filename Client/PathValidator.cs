using Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class PathValidator : IPathValidator
    {
        public void ValidatePath(string path)
        {
			try
			{
                Path.GetFullPath(path);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ОШИБКА: Неправильно указан путь");
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("ОШИБКА: Неправильно указан путь");
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine("ОШИБКА: Слишком длинный путь");
            }
        }
    }
}
