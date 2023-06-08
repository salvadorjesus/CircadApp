using AppCircada.Messages;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;

namespace AppCircada.ViewModel;

[QueryProperty("NumQuestions", "NumQuestions")]
public partial class QuizPageViewModel : BaseViewModel
{
    
    private ObservableCollection<QuizQuestionWrapper> quizQuestions = new();
    public ObservableCollection<QuizQuestionWrapper> QuizQuestions
    {
        get => quizQuestions;
        set => SetProperty(ref quizQuestions, value);
    }

    [ObservableProperty]
    int numQuestions;

    [ObservableProperty]
    int questionsAnswered;

    public bool TestCompleted
    {
        get => NumQuestions == QuestionsAnswered;
    }

     public async Task LoadQuizAsync()
    {
        var loadedQuizQuestions = await QuizService.GetQuizAsync(NumQuestions);

        var newCollection = new ObservableCollection<QuizQuestionWrapper>();
        foreach (var question in loadedQuizQuestions)
        {
            var questionWrapper = new QuizQuestionWrapper(question);
            questionWrapper.PropertyChanged += OnQuestionWrapperPropertyChanged;
            newCollection.Add(questionWrapper);
        }

        QuizQuestions = newCollection;
    }

    private async void OnQuestionWrapperPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(QuizQuestionWrapper.QuestionUnasnwered))
        {
            if ((sender as QuizQuestionWrapper).QuestionUnasnwered == false)
            {
                QuestionsAnswered++;
                if (QuestionsAnswered == NumQuestions)
                {
                    //Test completed
                    await Shell.Current.Navigation.PushModalAsync(new QuizResultsPage(this));
                }
            }
        }
    }
}
