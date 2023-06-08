namespace AppCircada.View;

public partial class QuizStartPage : ContentPage
{
	public QuizStartPage(QuizSelectorViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as QuizSelectorViewModel).UpdateTrophyInfoProperties();
    }
}