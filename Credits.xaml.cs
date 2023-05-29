using System.Windows;
using System.Windows.Input;

namespace MinecraftInjector;

public partial class Credits : Window
{
    public string AccentColor { get; set; }
    public Credits()
    {
        AccentColor = MainWindow.AccentColor;
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }
}