using Cafe.Models;
using System.Data.Entity;

namespace Cafe
{
    public static class DBContext
    {
        private static CafeEntities s_context;
        public static CafeEntities Context
        {
            get
            {
                if (s_context == null)
                {
                    UpdateContext();
                    return s_context;
                }
                else return s_context;
            }
            private set
            {
                s_context = value;
            }
        }
        public static void UpdateContext()
        {
            s_context = new CafeEntities();
            s_context.Measures.Load();
            s_context.Products.Load();
            s_context.Checks.Load();
            s_context.Purchases.Load();
        }
    }
}
