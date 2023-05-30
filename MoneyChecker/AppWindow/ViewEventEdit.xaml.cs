using MoneyChecker.Commands.CategoryEditor;
using MoneyChecker.Entities;
using MoneyChecker.Models;
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
        CalendarControl _celControl;

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
                MainWindow.MainViewModel.DataEventModel.DeleteDateEvent((DateEvent)ListViewEvents.SelectedItem);
                ListViewEvents.Items.Refresh();
            }
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {

            AddOrEditEvent addOr = new AddOrEditEvent();

            if (addOr.ShowDialog() == true)
            {
                DateEvent dateEvent = new DateEvent() { Date = _cel._date, Description = (addOr._dateEvent.Description)};

                _cel.GetDateEvents.Add(dateEvent);

                MainWindow.MainViewModel.DataEventModel.AddNewDateEvent(dateEvent);
                ListViewEvents.Items.Refresh();
            }
        }

        private void EditEvent_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewEvents.SelectedItem != null)
            {
                AddOrEditEvent addOr = new AddOrEditEvent((DateEvent)ListViewEvents.SelectedItem);

                if (addOr.ShowDialog() == true)
                {
                    DateEvent dateEvent = new DateEvent() { Date = _cel._date, Description = (addOr._dateEvent.Description) };
                    
                    MainWindow.MainViewModel.DataEventModel.EditDateEvent(dateEvent);
                    ListViewEvents.Items.Refresh();
                }
            }
        }

    }
}
