using MoneyChecker.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoneyChecker.AppWindow
{
    /// <summary>
    /// Логика взаимодействия для ViewEventEdit.xaml
    /// </summary>
    public partial class ViewEventEdit : Window
    {
        CalendarCell _cel;

        public ViewEventEdit(CalendarCell cell)
        {
            InitializeComponent();
            _cel = cell;
            ListViewEvents.ItemsSource = _cel.GetDateEvents;

        }

        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewEvents.SelectedItem != null)
            {
                _cel.GetDateEvents.Remove((DateEvent)ListViewEvents.SelectedItem);
                ListViewEvents.Items.Refresh();
            }
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            _cel.GetDateEvents.Add(new DateEvent() { data = _cel._date, Description = $"событие новое" });
            ListViewEvents.Items.Refresh();

        }
    }
}
