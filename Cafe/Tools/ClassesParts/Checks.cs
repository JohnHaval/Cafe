using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
