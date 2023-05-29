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
            calendarControl = new CalendarControl(ListViewCalendar);
            LabelCurentDate.Content = calendarControl.GetCurentDatePeriod;
        }

        private void ButtonPlusMonth_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            calendarControl.AddMonth();
            LabelCurentDate.Content = calendarControl.GetCurentDatePeriod;
        }

        private void ButtonMinusMonth_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            calendarControl.MinusMonth();
            LabelCurentDate.Content = calendarControl.GetCurentDatePeriod;
        }

        private void ButtonPlusYear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            calendarControl.AddYear();
            LabelCurentDate.Content = calendarControl.GetCurentDatePeriod;
        }

        private void ButtonMinusYear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            calendarControl.MinusYear();
            LabelCurentDate.Content = calendarControl.GetCurentDatePeriod;
        }
    }
}
