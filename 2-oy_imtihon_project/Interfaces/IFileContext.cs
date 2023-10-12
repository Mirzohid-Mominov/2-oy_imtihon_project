using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.Interfaces
{
    public interface IFileContext<T> where T : class
    {
        public IEnumerable<T> Readtext();
        public bool Writetext<T>(List<T> data);

    }
}
