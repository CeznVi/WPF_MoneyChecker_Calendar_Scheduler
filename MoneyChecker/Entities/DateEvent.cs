using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Entities
{

    /// <summary>
    /// Описывает событие
    /// </summary>
    public class DateEvent
    {
        /* /////-----------   Переменные   -----------\\\\\ */

        /// <summary>
        /// Дата события
        /// </summary>
        public DateTime data;

        /// <summary>
        /// Описание события
        /// </summary>
        public string Description { get; set; }

    }
}
