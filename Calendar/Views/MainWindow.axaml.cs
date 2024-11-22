using Avalonia;
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
        private void OnCalendarButtonClick(object sender, RoutedEventArgs e)
        {
            var calendarWindow = new CalendarWindow(currentDate, this); // Передаем текущую дату
            calendarWindow.Show();
        }
        public void SwitchToDate(DateTime newDate)
        {
            currentDate = newDate; // Обновляем текущую дату
            UpdateDateDisplay(); // Обновляем отображение даты
        }
        private void UpdateDateDisplay()
        {
            CalendarButton.Content = currentDate.ToString("dd MMMM yyyy");
        }
        private void OnPrevDateButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-1); //Здесь будем брать из базы данных предедущий день
            UpdateDateDisplay();
        }
        private void OnNextDateButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(1);  //Здесь будем брать из базы данных следующий день
            UpdateDateDisplay();
        }

    }
}
 