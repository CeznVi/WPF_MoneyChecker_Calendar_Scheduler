using Microsoft.Extensions.Logging;
using MoneyChecker.Entities;
using System;
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
    /// Логика взаимодействия для ViewEvent.xaml
    /// </summary>
    public partial class ViewEvent : Window
    {

        public ViewEvent(List<DateEvent> listEvent)
        {
            InitializeComponent();

            ListViewEvents.ItemsSource = listEvent;
        }
    }
}
