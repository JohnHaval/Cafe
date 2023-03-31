using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public static class DBContext
    {
        public static CafeEntities Context { get; private set; }
        public static void UpdateContext()
        {
            Context = new CafeEntities();            
        }
    }
}
