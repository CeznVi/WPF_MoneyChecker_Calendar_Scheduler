using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;


namespace MoneyChecker.Models
{
    public class CalendarControl
    {

        private ListView _listView;
        private DateTime _curDate = new DateTime();
        private List<CalendarCell> _cells;

        /* /////-----------   Конструктор   -----------\\\\\ */
        public CalendarControl(ListView ListViewCalendar)
        {
            _curDate = DateTime.Now;
            _listView = ListViewCalendar;
            Init();
        }

        /* /////-----------   Свойства   -----------\\\\\ */
        public string GetCurentDatePeriod
        {
            get 
            {
                return _curDate.ToString("MM yyyy");
            }
        }

        /* /////-----------   Методы   -----------\\\\\ */

        /// <summary>
        /// Добавить Месяц к текущей дате
        /// </summary>
        public void AddMonth()
        {
            _curDate = _curDate.AddMonths(1);
            Init();
        }
        
        /// <summary>
        /// Отнять Месяц от текущей даты
        /// </summary>
        public void MinusMonth()
        {
            _curDate = _curDate.AddMonths(-1);
            Init();
        }

        /// <summary>
        /// Добавить Год к текущей дате
        /// </summary>
        public void AddYear()
        {
            _curDate = _curDate.AddYears(1);
            Init();
        }

        /// <summary>
        /// Отнять Год от текущей даты
        /// </summary>
        public void MinusYear()
        {
            _curDate = _curDate.AddYears(-1);
            Init();
        }

        /// <summary>
        /// Инициализация ячеек календаря
        /// </summary>
        private void Init()
        {
            int _days = DateTime.DaysInMonth(_curDate.Year, _curDate.Month);

            _cells = new List<CalendarCell>();
            CalendarCell cell;

            


            for (int i = 0; i < _days; i++)
            {
                cell = new CalendarCell() { _date = new DateTime(_curDate.Year, _curDate.Month, i + 1) };

                _cells.Add(cell);
            }

            _listView.ItemsSource = _cells;

        }

        /// <summary>
        /// Добавить дней перед первым числом в зависимости от дня недели первого числа
        /// </summary>
        private void AddCellsBeforeFirstDay()
        {
            DateTime firstDayOfMonth = new DateTime(_curDate.Year, _curDate.Month, 1);
            
            DateTime monthBefore = new DateTime(_curDate.Year, _curDate.AddMonths(-1).Month, 1);
            int _days = DateTime.DaysInMonth(monthBefore.Year, monthBefore.Month);

            if (firstDayOfMonth.DayOfWeek == DayOfWeek.Monday)
            {
                return;
            }
            else
            {
                CalendarCell cell;

                for (int i = _days - Convert.ToInt32(firstDayOfMonth.DayOfWeek); i < _days; i++) 
                {
                    cell = new CalendarCell() { _date = new DateTime(monthBefore.Year, monthBefore.Month, _days + i) };
                    _cells.Add(cell);
                }
                
            }






          


        }
    }


    public class CalendarCell
    {

        /* /////-----------   Переменные   -----------\\\\\ */
        /// <summary>
        /// Хранит дату
        /// </summary>
        public DateTime _date;


        /* /////-----------   Свойства   -----------\\\\\ */

        /// <summary>
        /// Возвращает дату в виде строки
        /// </summary>
        public string Date { get { return _date.Day.ToString(); } }

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
                if(this.DayOfWeekEnum == System.DayOfWeek.Saturday || this.DayOfWeekEnum == System.DayOfWeek.Sunday)
                    return Color.Red.Name;
                else 
                    return Color.White.Name;
            } 
        }

    }

}
