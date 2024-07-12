

using Microsoft.Maui.Layouts;

namespace AutWindowTest;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    /// <summary>
    /// Переход на основную страницу приложения
    /// </summary>
    private void RedirectToMainPage()
    {
        var newMainPage = new MainPage();
        App.Current.MainPage.Navigation.PushAsync(newMainPage);
        NavigationPage.SetHasNavigationBar(newMainPage, false);
        NavigationPage.SetHasBackButton(newMainPage, false);
        SetWindowsProperties(App.Current.MainPage.GetParentWindow());
    }

    /// <summary>
    /// Изменение размеров окна программы
    /// </summary>
    /// <param name="window"></param>
    private void SetWindowsProperties(Window window)
    {
        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
        window.MinimumWidth = 400;
        window.MinimumWidth = 600;
        window.MaximumHeight = int.MaxValue;
        window.MaximumWidth = int.MaxValue;
        window.Height = displayInfo.Height / displayInfo.Density * 0.9;
        window.Width = displayInfo.Width / displayInfo.Density * 0.9;
    }

    void Auth_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Login.Text) || string.IsNullOrEmpty(Password.Text)) { 
            if(string.IsNullOrWhiteSpace(Login.Text)) { show_empty_Login.IsVisible = true; }
            if (string.IsNullOrWhiteSpace(Password.Text)) { show_empty_Pass.IsVisible = true; }
            return;
        }           
        
        if (Login.Text == "Admin" && Password.Text == "123")
            {
                RedirectToMainPage();
            }
            else        
            {
                Password.Text = "";
                w_error.IsVisible = true;                                                     
                show_empty_Login.IsVisible = string.IsNullOrWhiteSpace(Login.Text) ? true : false;
                show_empty_Pass.IsVisible = true;
            }            
    }

    private void Login_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Login.Text))
        {
            show_empty_Login.IsVisible = false;
            w_error.IsVisible = false;
        }
    }

    private void Password_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(Password.Text))
        {
            show_empty_Pass.IsVisible = false;
            w_error.IsVisible = false;
        }
    }
}