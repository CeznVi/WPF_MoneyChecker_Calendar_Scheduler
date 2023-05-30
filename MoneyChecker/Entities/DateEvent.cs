using System;

namespace MoneyChecker.Entities
{

    /// <summary>
    /// Описывает событие
    /// </summary>
    public class DateEvent
    {
        /* /////-----------   Переменные   -----------\\\\\ */
        public int Id { get; set; }

        /// <summary>
        /// Дата события
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Описание события
        /// </summary>
        public string Description { get; set; }

    }
}
