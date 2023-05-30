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
    /// Логика взаимодействия для AddOrEditEvent.xaml
    /// </summary>
    public partial class AddOrEditEvent : Window
    {
        public DateEvent _dateEvent;

        public AddOrEditEvent(DateEvent dateEvent)
        {
            InitializeComponent();
            _dateEvent = dateEvent;
            TextBoxDescr.Text = _dateEvent.Description;
        }

        public AddOrEditEvent()
        {
            InitializeComponent();
            _dateEvent = new DateEvent();
        }




        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxDescr.Text.Length > 5)
            {
                _dateEvent.Description = TextBoxDescr.Text;

                DialogResult = true;
                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
