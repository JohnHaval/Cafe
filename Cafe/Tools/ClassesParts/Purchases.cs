namespace Cafe.Models
{
    /// <summary>
    /// Вторая часть классов покупок
    /// </summary>
    public partial class Purchases
    {
        public decimal ProductCost { get => (Products != null) ? Products.Price * ProductCount : 0; }
    }
}
