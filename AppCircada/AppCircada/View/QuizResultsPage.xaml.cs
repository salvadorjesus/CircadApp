using SkiaSharp.Extended.UI.Controls;
using AppCircada.View.Converters;
using System.Globalization;

namespace AppCircada.View;

public partial class QuizResultsPage : ContentPage
{
	public QuizResultsPage(QuizPageViewModel quizPageVM)
	{
		InitializeComponent();
		var viewModel = new QuizResultsViewModel(quizPageVM);
        BindingContext = viewModel;

        /* Selecting the animation using the converter and the viewModel property QuizResultType.
         * This should go in the XAML but does not work with the current version of skiasharp extension.
         * I am not implementing the binding since it’s not necessary.
         */
        var imgSrc = new SKFileLottieImageSource();
        var converter = new QuizResultTypeToFileNameConverter();
        
        imgSrc.File = (string)converter.Convert(viewModel.QuizResult, typeof(QuizResultType), null, CultureInfo.CurrentCulture);
        LottieView.Source = imgSrc;
	}

    /* Given that test results could be shown in popups or others, in addition to this page,
     * I prefer to keep the back navigation logic in the code behind, leaving the viewmodel
     * abstract and easily reusable if a change is needed in the future.
     * */
        private async void Volver_Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopModalAsync();
    }
}