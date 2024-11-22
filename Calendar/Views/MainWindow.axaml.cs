using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Calendar.Views
{
    public partial class MainWindow : Window
    {
        private DateTime currentDate;
        public MainWindow()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            UpdateDateDisplay();
        }
        private void UpdateDateDisplay()
        {
            CurrentDateText.Text = currentDate.ToString("dd MMMM yyyy");
        }
        private void OnPrevDateButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-1); //«десь будем брать из базы данных предедущий день
            UpdateDateDisplay();
        }
        private void OnNextDateButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(1);  //«десь будем брать из базы данных следующий день
            UpdateDateDisplay();
        }
    }
}