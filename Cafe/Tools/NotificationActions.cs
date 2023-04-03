using System.Windows;

namespace Cafe.Tools
{
    /// <summary>
    /// Класс для отображения сообщений пользователю
    /// </summary>
    public static class NotificationActions
    {
        /// <summary>
        /// Отображение о необходимости выбора объекта из списка для изменения
        /// </summary>
        public static void NeedSelectForUpdate()
        {
            MessageBox.Show("Для изменения элемента из списка, его необходимо выбрать!", "Изменение",
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        /// <summary>
        /// Отображение об отсутствии записей в выпадающем списке
        /// </summary>
        public static void NoComboList()
        {
            MessageBox.Show("Выпадающий список пуст! Невозможно добавить запись без данных в нем!", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Ошибка конвертации
        /// </summary>
        public static void IntError()
        {
            MessageBox.Show("Числовые поля имеют некоррекные значения! Проверьте правильность!", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Недостаточно на остатках для списания
        /// </summary>
        public static void NoHoldCount()
        {
            MessageBox.Show("Продукта нет в таком количестве на остатках! Невозможно добавить.", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Сообщение о закрытии окна
        /// </summary>
        /// <returns>Ответ пользователя, хочет ли он закрыть окно</returns>
        public static bool WindowClosing()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите закрыть программу?", "Закрытие программы",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return true;
            else return false;
        }

        #region Сообщения удаления

        /// <summary>
        /// Сообщение о необходимости выбрать объект из списка для удаления
        /// </summary>
        public static void NeedSelectBeforeRemove()
        {
            MessageBox.Show("Для удаления элемента из списка, его необходимо выбрать!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        /// <summary>
        /// Сообщение о проблеме с ключами
        /// </summary>
        public static void KeyProblem()
        {
            MessageBox.Show("Невозможно удалить, так как запись используется в других таблицах или она уже удалена!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
        /// <summary>
        /// Сообщение об удалении объекта из списка
        /// </summary>
        /// <returns>Ответ-подтверждение</returns>
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
