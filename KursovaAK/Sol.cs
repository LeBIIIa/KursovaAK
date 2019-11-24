using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler
{
    public interface ISol
    {
        void Run(string compiled, string report);
    }
}
