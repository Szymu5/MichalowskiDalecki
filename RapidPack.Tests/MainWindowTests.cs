using Avalonia.Headless.XUnit;
using Xunit;
using RapidPack;

namespace RapidPack.Tests;

public class MainWindowTests
{
    // Test sprawdzający czy okno się odpala
    [AvaloniaFact]
    public void CreateWindow_ShouldCreateANewWindow()
    {
        var window = new MainWindow();
        Assert.NotNull(window);
    }

    // Testy logiki (wymagane przez szefa Jana)
    [Fact]
    public void Test_WagaPowyzej30_Blad()
    {
        var logic = new ParcelLogic();
        Assert.Equal(-1, logic.Calculate(31, 10, 10, 10, false, 0));
    }

    [Fact]
    public void Test_Paleta_CenaStala()
    {
        var logic = new ParcelLogic();
        Assert.Equal(100.0, logic.Calculate(10, 200, 200, 200, false, 2));
    }

    [Fact]
    public void Test_Gabaryt_Dolicza50Procent()
    {
        var logic = new ParcelLogic();
        // 60+60+60 = 180 (>150). Baza 10 * 1.5 = 15.
        Assert.Equal(15.0, logic.Calculate(0, 60, 60, 60, false, 0));
    }
}
//