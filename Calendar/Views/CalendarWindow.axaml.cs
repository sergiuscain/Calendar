using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using Avalonia.VisualTree;

namespace Calendar.Views;

public partial class CalendarWindow : Window
{
    private DateTime selectedDate;
    private MainWindow mainWindow;
    public CalendarWindow(DateTime currentDate, MainWindow mainWindow)
    {
        InitializeComponent();
        DatePicker.SelectedDate = currentDate;
        this.mainWindow = mainWindow;
    }

    private void OnSelectedDateChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        if (DatePicker.SelectedDate.HasValue)
        {
            selectedDate = DatePicker.SelectedDate.Value;
        }
    }

    private void OnSelectButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
            
        mainWindow.SwitchToDate(selectedDate); // Передаем выбранную дату в главное окно
        Close();


    }
}