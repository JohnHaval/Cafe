using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
