using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public static class DBContext
    {
        private static CafeEntities _context;
        public static CafeEntities Context
        {
            get
            {
                if (_context == null)
                {
                    UpdateContext();
                    return _context;
                }
                else return _context;
            }
            private set
            {
                _context = value;
            }
        }
        public static void UpdateContext()
        {
            _context = new CafeEntities();
            _context.Measures.Load();
            _context.Products.Load();
            _context.Checks.Load();
            _context.Purchases.Load();
        }
    }
}
