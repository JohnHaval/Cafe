using Cafe.Models;

namespace Cafe.Tools
{
    public static class CheckActions
    {
        public static decimal GetDiscount(decimal cost)
        {
            if (cost >= 300 && cost <= 500) return cost / 100 * 3;
            if (cost >= 501 && cost <= 1000) return cost / 100 * 5;
            if (cost >= 1001 && cost <= 5000) return cost / 100 * 7;
            if (cost > 5000) return cost / 100 * 10;
            return 0;
        }
        public static bool HasHoldCount(Products product, int count)
        {
            if ((product.HoldCount - count) < 0) return false;
            else return true;
        }
    }
}
