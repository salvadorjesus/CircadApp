namespace AppCircada.ViewModel;

public partial class MainPageViewModel : BaseViewModel
{

    public MainPageViewModel()
    {
        Title = "Circada 2023";
    }

    [RelayCommand]
    async void OpenCircadaWeb()
    {
        await OpenBrowser("https://festivalcircada.com/calendario/");
    }

    [RelayCommand]
    async void OpenVentaEntradasWeb()
    {
        await OpenBrowser("https://festivalcircada.com/venta-de-entradas/");
    }

    [RelayCommand]
    async Task GoToQuizStartAsync()
    {
        await Shell.Current.GoToAsync("//QuizStartPage");
    }

    async Task OpenBrowser(string address)
    {
        try
        {
            Uri uri = new Uri(address);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception)
        {
            // An unexpected error occurred. No browser may be installed on the device.
        }
    }
}
