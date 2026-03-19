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

        if (waga > 30) 
        {
            Podsumowanie.Text = "BŁĄD: Max 30kg!";
            return;
        }

        double wynik = 0;

        if (typIndex == 2) 
        {
            wynik = 100.0;
        }
        else 
        {
            wynik = 10.0 + (waga * 2.0);
            if (typIndex == 1) wynik += 10.0;
            if ((wys + szer + gleb) > 150) wynik *= 1.5;
            if (ekspres) wynik += 15.0;
        }

        Podsumowanie.Text = $"CENA: {wynik:N2} zł";
    }
}