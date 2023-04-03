using Cafe.Models;
using System.Data.Entity;

namespace Cafe
{/// <summary>
/// Класс для работы с контекстом
/// </summary>
    public static class DBContext
    {
        private static CafeEntities s_context;
        /// <summary>
        /// Контекст, хранящий в себе данные, полученные из БД
        /// </summary>
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
        /// <summary>
        /// Обновляет данные контекста
        /// </summary>
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
