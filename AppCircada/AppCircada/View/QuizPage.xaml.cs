using AppCircada.Messages;
using CommunityToolkit.Mvvm.Messaging;

namespace AppCircada.View;

public partial class QuizPage : ContentPage, IRecipient<ShellOnNavigatingMessage>
{
	public QuizPage(QuizPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    /* This page will be notified when the Shell is trying to perform any navigation from any of its managed pages.
    * It is the responsibility of this page to check is the shell is trying to abandon itself. If that is the case, the
    * viewModel will be consulted if the navigation can happen or not (is the test completed or not).
    * In this case, if the quiz is not completed, the user will be asked.
    * The viewModel should not perform this check itself, given that it should not have any knowledge of the view.
    */
    public void Receive(ShellOnNavigatingMessage message)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            ShellNavigatingEventArgs args = message.Value;
            if (args.Current.Location.OriginalString.EndsWith(this.GetType().Name))
            { //Trying to abandom this page.
                if (!(BindingContext as QuizPageViewModel).TestCompleted)
                {
                    ShellNavigatingDeferral token = args.GetDeferral();

                    var abandon = await DisplayAlert("¿Abandonar el Quiz?", "Aun quedan preguntas por responder.", "Seguir respondiendo", "Abandonar");
                    if (abandon)
                    {
                        args.Cancel();
                    }
                    token.Complete();
                }
            }
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        WeakReferenceMessenger.Default.Register<ShellOnNavigatingMessage>(this);

        var viewModel = BindingContext as QuizPageViewModel;
        //Do not reload a Quiz if the Test is completed (that means the navigation is
        //coming back from the results page).
        if (!viewModel.TestCompleted)
        {
            await viewModel.LoadQuizAsync();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WeakReferenceMessenger.Default.Unregister<ShellOnNavigatingMessage>(this);
    }
}