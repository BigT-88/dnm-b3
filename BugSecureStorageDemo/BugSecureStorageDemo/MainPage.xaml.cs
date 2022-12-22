using BugSecureStorageDemo.Services;

namespace BugSecureStorageDemo;

public partial class MainPage : ContentPage
{
    private readonly IDemoSecureStorage _secureStorage = new SecureStorageService();

    int count = 0;

    private string item2Value = new string(string.Empty);
    public string Item2Value
    {
        get { return item2Value; }
        set
        {
            item2Value = value;
            OnPropertyChanged();
        }
    }

    public MainPage()
    {
        InitializeComponent();
        this.BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        secureStorageProcess();
    }

    private async void secureStorageProcess()
    {
        try
        {
            await _secureStorage.SetAsync("Item1Key", "Value1");
            await _secureStorage.SetAsync("Item2Key", "Value2");
            await _secureStorage.SetAsync("Item3Key", "Value3");

            var isSecureStorageEnabled = await _secureStorage.IsSecureStorageEnabled();

            Item2Value = _secureStorage.GetAsync("Item2Key").Result;
        }
        catch (AggregateException e)
        {
            var message = e.Message;
        }
        catch (Exception e)
        {
            var message = e.Message;
        }
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
