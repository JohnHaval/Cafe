using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cafe.Tools
{
    public static class CheckActions
    {
        public static decimal GetDiscount(decimal cost)
        {
            if (cost >= 300 && cost <= 500) return cost / 100 * 3;
            if (cost >= 501 && cost <= 1000) return cost / 100 * 5;
            if (cost >= 1001 && cost <= 5000) return cost / 100 * 7;
            return cost / 100 * 10;
        }
        public static bool HasHoldCount(Products product)
        {
            if (product.HoldCount <= 0) return false;
            else return true;
        }
        public static void RestorePurchases(List<Purchases> startPurchases)
        {
            var newPurchases = from s in DBContext.Context.Purchases
                               where !startPurchases.Any()
                               select s;

            foreach (var item in newPurchases.ToList())
            {
                Products product = item.Products;//Получение для будущего возврата к остаткам
                DBContext.Context.Purchases.Remove(item);

                DBContext.Context.SaveChanges();

                product.HoldCount++;//Возвращение в остатки

                DBContext.Context.SaveChanges();
            }

            var oldPurchases = from s in startPurchases
                               where !DBContext.Context.Purchases.Any()
                               select s;

            foreach (var item in oldPurchases.ToList())
            {
                Products product = item.Products;//Получение для будущего возврата к остаткам
                DBContext.Context.Purchases.Add(item);

                DBContext.Context.SaveChanges();

                product.HoldCount--;//Возвращение в остатки

                DBContext.Context.SaveChanges();
            }
        }
    }
}
