using MoneyChecker.AppWindow;
using MoneyChecker.Entities;
using MoneyChecker.Models;
using System.Drawing;
using System.Windows;
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

        /// <summary>
        /// При изменении выделения показывает 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewCalendar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewCalendar.SelectedValue is (CalendarCell) && ListViewCalendar.SelectedValue != null)
            {
                CalendarCell tmp = (CalendarCell)ListViewCalendar.SelectedValue;

                if (tmp.CountEvent != 0)
                {
                    ViewEvent windowView = new ViewEvent(tmp.GetDateEvents);
                    windowView.ShowDialog();
                }
            }

        }

    }
}
