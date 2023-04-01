using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    /// <summary>
    /// Вторая часть классов покупок
    /// </summary>
    public partial class Purchases
    {
        public decimal ProductCost { get => Products.Price * ProductCount; }
    }
}
