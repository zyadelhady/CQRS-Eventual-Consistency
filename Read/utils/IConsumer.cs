using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.utils
{
   public interface IConsumer<T>
    {
        public void Exexute(T Message);
    }
}
