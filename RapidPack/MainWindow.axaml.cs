using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace RapidPack;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        PrzyciskWyceny.Click += OnCalculateClick;
    }

    private void OnCalculateClick(object? sender, RoutedEventArgs e)
    {
        double.TryParse(WeightTextBox.Text, out double waga);
        double.TryParse(HeightTextBox.Text, out double wys);
        double.TryParse(WidthTextBox.Text, out double szer);
        double.TryParse(DepthTextBox.Text, out double gleb);
        
        bool ekspres = PrzesylkaEkspresowa.IsChecked ?? false;
        int typIndex = TypPrzesylki.SelectedIndex; 

