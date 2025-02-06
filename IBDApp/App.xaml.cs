
using IBDApp.Views;

namespace IBDApp
{
    public partial class App : Application
    {
        private readonly Window _mainWindow;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _mainWindow = serviceProvider.GetService<MainWindow>();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return _mainWindow;

        }
    }
}
