using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Calendar.Models;
using Calendar.Services;
using System;

namespace Calendar.Views
{
    public partial class MainWindow : Window
    {
        private DateTime currentDate;
        private Card Card;
        public static CardStorage CardStorage = new CardStorage();
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
            Card = CardStorage.TryFindCard(newDate); //

            UpdateDateDisplay(); // Обновляем отображение даты
        }
        private void UpdateDateDisplay()
        {
            CalendarButton.Content = currentDate.ToString("dd MMMM yyyy");
        }
        private void OnPrevDateButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Card =  CardStorage.TryFindCard(currentDate.AddDays(-1)); 
            currentDate = Card.Date;
            UpdateDateDisplay();
        }
        private void OnNextDateButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Card =  CardStorage.TryFindCard(currentDate.AddDays(+1));
            currentDate = Card.Date;
            UpdateDateDisplay();
        }

    }
}
 