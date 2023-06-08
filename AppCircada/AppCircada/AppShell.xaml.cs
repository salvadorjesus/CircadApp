using AppCircada.Messages;
using AppCircada.View;
using CommunityToolkit.Mvvm.Messaging;

namespace AppCircada;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Route registration of pages that are not in the flyout.
		Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));
    }

    /*Alert pages that might want to control navigating away from them (i.e.: Do display a warning to the user).*/
    protected override void OnNavigating(ShellNavigatingEventArgs args)
	{
		base.OnNavigating(args);
		WeakReferenceMessenger.Default.Send(new ShellOnNavigatingMessage(args));
	}
}
