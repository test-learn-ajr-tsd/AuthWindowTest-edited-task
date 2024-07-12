
namespace AutWindowTest
{
    public partial class App : Application
    {
        private const int _loginWindowHeight = 310;
        private const int _loginWindowWidth = 615;

        public App()
        {
            InitializeComponent();
            var navigationPage = new NavigationPage(new LoginPage());
            MainPage = navigationPage;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Title = "AWS Caesar";
            window.Height = _loginWindowHeight;
            window.Width = _loginWindowWidth;
            window.MinimumHeight = _loginWindowHeight;
            window.MinimumWidth = _loginWindowWidth;
            window.MaximumHeight = _loginWindowHeight;
            window.MaximumWidth = _loginWindowWidth;

            return window;
        }
    }
}
