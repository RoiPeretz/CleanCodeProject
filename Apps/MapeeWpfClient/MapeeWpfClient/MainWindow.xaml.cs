using System.Windows;
using wpfClient.Core.Services;

namespace MapeeWpfClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IEntityViewModel entityViewModel)
    {
        InitializeComponent();
        DataContext = entityViewModel;
    }
}