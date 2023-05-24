using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MoneyChecker.Models
{
    public class CalendarControl
    {
        public Grid grid;
        private DateTime _curDate = new DateTime();

        private int _days;

        public CalendarControl(Grid grid)
        {
            _curDate = DateTime.Now;
            this.grid = grid;
            Init();
        }

        private void Init()
        {

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            _days = DateTime.DaysInMonth(_curDate.Year, _curDate.Month);

            Grid gridDay;

            TextBlock textBlock;

            for (int i = 0; i < _days; i++) 
            {
                textBlock = new TextBlock();

                textBlock.Text = i.ToString();
                textBlock.FontSize = 90;


                grid.Children.Add(textBlock);

            }


        }


    }
}
