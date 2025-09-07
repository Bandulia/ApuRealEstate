using ApuRealEstate.Wpf.ViewModels;

namespace ApuRealEstate.Wpf;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
