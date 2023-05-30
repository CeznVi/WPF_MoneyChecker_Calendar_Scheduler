using MoneyChecker.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyChecker.Entities
{
    /// <summary>
    /// Клас описывающий сущность клетки (1дня) календаря
    /// </summary>
    public class CalendarCell
    {

        /* /////-----------   Переменные   -----------\\\\\ */
        /// <summary>
        /// Хранит дату
        /// </summary>
        public DateTime _date;

        /// <summary>
        /// Переменная для хранения событий
        /// </summary>
        private List<DateEvent> _listDataEvent = new List<DateEvent>();


        /* /////-----------   Свойства   -----------\\\\\ */

        /// <summary>
        /// Возвращает дату в виде строки
        /// </summary>
        public string Date { get { return _date.Day.ToString(); } }

        /* Для дебага */
        ////---------------
        ///public string Date { get { return _date.ToString("d"); } }
        ////---------------

        /// <summary>
        /// Возвращает строку с именем дня недели
        /// </summary>
        public string DayOfWeek { get { return _date.ToString("dddd"); } }

        /// <summary>
        /// Приводит день недели к системному Enum
        /// </summary>
        private DayOfWeek DayOfWeekEnum { get { return _date.DayOfWeek; } }

        /// <summary>
        /// Возвращает цвет ячейки в виде строки (для выходных дней другой цвет)
        /// </summary>
        public string CellColor
        {
            get
            {
                if (this.DayOfWeekEnum == System.DayOfWeek.Saturday || this.DayOfWeekEnum == System.DayOfWeek.Sunday)
                    return Color.Red.Name;
                else
                    return Color.White.Name;
            }
        }

        /// <summary>
        /// Возвращает количество событий в данном дне
        /// </summary>
        public int CountEvent { get { return _listDataEvent.Count; } }

        public string CountEventInDayString { get { return $"Событий: {CountEvent}"; } }

        public Visibility IsVisibleTextBlock 
        { 
            get 
            { 
                if(CountEvent > 0)
                    return Visibility.Visible;
                else 
                    return Visibility.Hidden;
            } 
        }

        /// <summary>
        /// Возвращает список 
        /// </summary>
        public List<DateEvent> GetDateEvents { get { return _listDataEvent; } }

    }

}
