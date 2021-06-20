using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ICounterService
    {
        int GetNumberOfTextAppearance(string path, string searchTerm);
        string ExtractFileName(string path); 
    }
}
