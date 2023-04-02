namespace Cafe.Models
{
    /// <summary>
    /// Вторая часть класса чеков
    /// </summary>
    public partial class Checks
    {
        public string IsComplexLunchString { get => (IsComplexLunch) ? "Да" : "Нет"; }
    }
}
