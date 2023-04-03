using Cafe.Models;

namespace Cafe.Tools
{/// <summary>
/// Класс для работы с чеками. Включает в себя дополнительные модули.
/// </summary>
    public static class CheckActions
    {
        /// <summary>
        /// Позволяет получить рассчитанную скидку
        /// </summary>
        /// <param name="cost">Стоимость всех товаров</param>
        /// <returns>Возвращает рассчитанную скидку.</returns>
        public static decimal GetDiscount(decimal cost)
        {
            if (cost >= 300 && cost <= 500) return cost / 100 * 3;
            if (cost >= 501 && cost <= 1000) return cost / 100 * 5;
            if (cost >= 1001 && cost <= 5000) return cost / 100 * 7;
            if (cost > 5000) return cost / 100 * 10;
            return 0;
        }
        /// <summary>
        /// Позволяет узнать, хватает ли остатков для покупки товара в указанном количестве
        /// </summary>
        /// <param name="product">Продукт, имеющий количество на остатках</param>
        /// <param name="count">Количество для списания</param>
        /// <returns>true, если хватает для списания, false - не хватает остатков для списания</returns>
        public static bool HasHoldCount(Products product, int count)
        {
            if ((product.HoldCount - count) < 0) return false;
            else return true;
        }
    }
}
