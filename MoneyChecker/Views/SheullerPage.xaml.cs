using MoneyChecker.AppWindow;
using MoneyChecker.Entities;
using MoneyChecker.Models;
using System;
using System.Windows.Controls;

namespace MoneyChecker.Views
{
    /// <summary>
    /// Логика взаимодействия для SheullerPage.xaml
    /// </summary>
    public partial class SheullerPage : Page
    {
        CalendarControl calendarControl;


        public SheullerPage()
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
            CalendarCell tmp = (CalendarCell)ListViewCalendar.SelectedValue;
            ViewEventEdit windowView = new ViewEventEdit(tmp);
            windowView.ShowDialog();
            ListViewCalendar.Items.Refresh();
        }

        private void LabelCurentDate_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            calendarControl.SetDate(DateTime.Now);
            LabelCurentDate.Content = calendarControl.GetCurentDatePeriod;
        }
    }
}
