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

        var logic = new ParcelLogic();
        double wynik = logic.Calculate(waga, wys, szer, gleb, ekspres, typIndex);

        if (wynik == -1)
        {
            Podsumowanie.Text = "BŁĄD: Max 30kg!";
        }
        else
        {
            Podsumowanie.Text = $"CENA: {wynik:N2} zł";
        }
    }
}

public class ParcelLogic
{
    public double Calculate(double waga, double wys, double szer, double gleb, bool ekspres, int typIndex)
    {
        if (waga > 30) return -1;
        if (typIndex == 2) return 100.0;

        double wynik = 10.0 + (waga * 2.0);
        if (typIndex == 1) wynik += 10.0;
        if ((wys + szer + gleb) > 150) wynik *= 1.5;
        if (ekspres) wynik += 15.0;
        
        return wynik;
    }
}