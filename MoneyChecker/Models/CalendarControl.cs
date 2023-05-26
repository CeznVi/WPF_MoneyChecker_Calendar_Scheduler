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

        public CalendarControl(ListView ListViewCalendar)
        {
            _curDate = DateTime.Now;
            _listView = ListViewCalendar;
            Init();
        }

        private void Init()
        {
            int _days = DateTime.DaysInMonth(_curDate.Year, _curDate.Month);

            _cells = new List<CalendarCell>();
            CalendarCell cell;

            for (int i = 0; i < _days; i++)
            {
               cell  = new CalendarCell() { _date = new DateTime(_curDate.Year, _curDate.Month, i + 1) };

                _cells.Add(cell);
            }

            _listView.ItemsSource = _cells;

            foreach (var item in _listView.ItemsPanel.Resources.OfType<Grid>())
            {
                if(item is Grid) 
                {
                    item.Background = System.Windows.Media.Brushes.Red;
                
                }
            }

        }


    }


    public class CalendarCell
    {
        public DateTime _date;


        public string Date { get { return _date.Day.ToString(); } }

        public string DayOfWeek { get { return _date.ToString("dddd"); } }

        public DayOfWeek DayOfWeekEnum { get { return _date.DayOfWeek; } }

        public Color CellColor { get { } }

    }

}
