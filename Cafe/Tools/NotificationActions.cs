using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cafe.Tools
{
    public static class NotificationActions
    {
        public static void NeedSelectForUpdate()
        {
            MessageBox.Show("Для изменения элемента из списка, его необходимо выбрать!", "Изменение", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void NoComboList()
        {
            MessageBox.Show("Выпадающий список пуст! Невозможно добавить запись без данных в нем!", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void IntError()
        {
            MessageBox.Show("Числовые поля имеют некоррекные значения! Проверьте правильность!", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void NoHoldCount()
        {
            MessageBox.Show("Продукта нет в таком количестве на остатках! Невозможно добавить.", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }    

        #region Сообщения удаления
        public static void NeedSelectBeforeRemove()
        {
            MessageBox.Show("Для удаления элемента из списка, его необходимо выбрать!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public static void KeyProblem()
        {
            MessageBox.Show("Невозможно удалить, так как запись используется в других таблицах!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
        public static bool GetRemoveResponse()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить выбранное в списке?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else return false;
        }
        #endregion

    }
}
