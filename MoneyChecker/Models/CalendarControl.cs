using MoneyChecker.Entities;
using MoneyChecker.ViewsModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace MoneyChecker.Models
{
    public class CalendarControl
    {
        private DateTime _curDate;

        private ListView _listView;

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

        public ListView ListView { get { return _listView; } }


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
        /// Устанавливает дату
        /// </summary>
        /// <param name="date"></param>
        public void SetDate(DateTime date) 
        { 
            _curDate = date;
            Init();
        }


        /* /////-----------  ПРИВАТНЫЕ Методы   -----------\\\\\ */

        /// <summary>
        /// Инициализация ячеек календаря
        /// </summary>
        private void Init()
        {
            int _days = DateTime.DaysInMonth(_curDate.Year, _curDate.Month);

            _cells = new List<CalendarCell>();
            CalendarCell cell;

            AddCellsBeforeFirstDay();


            for (int i = 0; i < _days; i++)
            {
                cell = new CalendarCell() { _date = new DateTime(_curDate.Year, _curDate.Month, i + 1) };

                cell.GetDateEvents.AddRange(MainWindow.MainViewModel.DataEventModel.GetDataEventByDate(cell._date));

                _cells.Add(cell);
            }

            AddCellsAfterLastDay();

            _listView.ItemsSource = _cells;

        }

        /// <summary>
        /// Добавить дней перед первым числом в зависимости от дня недели первого числа
        /// </summary>
        private void AddCellsBeforeFirstDay()
        {
            DateTime firstDayOfMonth = new DateTime(_curDate.Year, _curDate.Month, 1);
            
            DateTime monthBefore = _curDate.AddMonths(-1);

            int _days = DateTime.DaysInMonth(monthBefore.Year, monthBefore.Month);

            if( firstDayOfMonth.DayOfWeek != DayOfWeek.Monday)
            {
                CalendarCell cell;

                int howMany = _days;

                if (firstDayOfMonth.DayOfWeek == DayOfWeek.Tuesday)
                    howMany = _days ;
                else if(firstDayOfMonth.DayOfWeek == DayOfWeek.Wednesday)
                    howMany = _days - 1;
                else if (firstDayOfMonth.DayOfWeek == DayOfWeek.Thursday)
                    howMany = _days - 2;
                else if (firstDayOfMonth.DayOfWeek == DayOfWeek.Friday)
                    howMany = _days - 3;
                else if (firstDayOfMonth.DayOfWeek == DayOfWeek.Saturday)
                    howMany = _days - 4;
                else if (firstDayOfMonth.DayOfWeek == DayOfWeek.Sunday)
                    howMany = _days - 5;

                for (int i = howMany; i <= _days; i++)
                {
                    cell = new CalendarCell() { _date = new DateTime(monthBefore.Year, monthBefore.Month, i) };
                    cell.GetDateEvents.AddRange(MainWindow.MainViewModel.DataEventModel.GetDataEventByDate(cell._date));
                    _cells.Add(cell);
                }
            }

        }

        /// <summary>
        /// Добавить дней после последнего числа в зависимости от дня недели последнего числа
        /// </summary>
        private void AddCellsAfterLastDay()
        {
            DateTime lastDayOfMonth = new DateTime(_curDate.Year, _curDate.Month, DateTime.DaysInMonth(_curDate.Year, _curDate.Month));

            DateTime monthAfter = _curDate.AddMonths(+1);

            int howMany = 0;

            if (lastDayOfMonth.DayOfWeek == DayOfWeek.Sunday)
                howMany = 0;
            else if(lastDayOfMonth.DayOfWeek == DayOfWeek.Saturday)
                howMany = 1;
            else if(lastDayOfMonth.DayOfWeek == DayOfWeek.Friday)
                howMany = 2;
            else if (lastDayOfMonth.DayOfWeek == DayOfWeek.Thursday)
                howMany = 3;
            else if (lastDayOfMonth.DayOfWeek == DayOfWeek.Wednesday)
                howMany = 4;
            else if (lastDayOfMonth.DayOfWeek == DayOfWeek.Tuesday)
                howMany = 5;
            else if (lastDayOfMonth.DayOfWeek == DayOfWeek.Monday)
                howMany = 6;

            CalendarCell cell;

            for (int i = 1; i <= howMany; i++)
            {
                cell = new CalendarCell() { _date = new DateTime(monthAfter.Year, monthAfter.Month, i) };
                cell.GetDateEvents.AddRange(MainWindow.MainViewModel.DataEventModel.GetDataEventByDate(cell._date));
                _cells.Add(cell);
            }
        }

    }



}
