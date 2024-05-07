using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    internal interface ITextExtractor
    {
        public string ExtractText(string path);
    }
}
