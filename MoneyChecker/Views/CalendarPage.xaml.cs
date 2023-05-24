using MoneyChecker.Models;
using System.Windows.Controls;

namespace MoneyChecker.Views
{
    /// <summary>
    /// Логика взаимодействия для CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        CalendarControl calendarControl;

        public CalendarPage()
        {

            InitializeComponent();
            calendarControl = new CalendarControl(GridCalendar);
        }



    }
}
