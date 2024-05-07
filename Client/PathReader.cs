using Client.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class PathReader : IPathReader
    {
        private readonly IPathValidator _validator;

        public PathReader(IPathValidator validator) 
        {
            _validator = validator;
        }

        public string GetPath()
        {
            bool directoryFound = false;
            string path = " ";

            while (!directoryFound)
            {
                Console.WriteLine("Введите путь к файлам:");
                path = @Console.ReadLine();

                _validator.ValidatePath(path);

                directoryFound = Directory.Exists(path);
                if (directoryFound == false)
                {
                    Console.WriteLine("По этому пути ничего не найдено!");
                }
            }
            Console.WriteLine("Директория найдена");
            return path;
        }
    }
}
