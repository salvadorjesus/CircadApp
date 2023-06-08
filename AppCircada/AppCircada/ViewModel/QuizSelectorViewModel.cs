using AppCircada.View;

namespace AppCircada.ViewModel;

public partial class QuizSelectorViewModel : BaseViewModel
{
    [ObservableProperty]
    QuizResultType trophyResult10Q;

    [ObservableProperty]
    QuizResultType trophyResult15Q;

    [ObservableProperty]
    QuizResultType trophyResult20Q;

    public QuizSelectorViewModel()
    {
        Title = "Quiz de Circo";
    }

    /**This function will be called during the OnAppearing function in the code behind.
    * In this way the trophy info will be updated after taking a Quiz. Note that the info is modified in
    * the QuizResultsViewModel. This is a minimal robust solution that does not add unnecessary dependencies,
    * although this check may be performed more than what is strictly necessary. Nevertheless, it does
    * not have any performance impact for the user.
    */
    internal void UpdateTrophyInfoProperties()
    {
        var userScore = UserScoreService.GetUserScore();
        QuizResultType scoreValueOrDefault;

        userScore.ScoreDictionary.TryGetValue(QuizType.AllQuestions10, out scoreValueOrDefault);
        TrophyResult10Q = scoreValueOrDefault;
        userScore.ScoreDictionary.TryGetValue(QuizType.AllQuestions15, out scoreValueOrDefault);
        TrophyResult15Q = scoreValueOrDefault;
        userScore.ScoreDictionary.TryGetValue(QuizType.AllQuestions20, out scoreValueOrDefault);
        TrophyResult20Q = scoreValueOrDefault;
    }

    [RelayCommand]
    async Task StartTest(int numQuestions)
    {
        await Shell.Current.GoToAsync($"QuizPage?NumQuestions={numQuestions}");
    }
}
