using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IBDApp.Views;

public partial class AppShell : Shell, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public AppShell()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
