using SkiaSharp.Extended.UI.Controls;
using SkiaSharp.Views.Maui.Controls;

namespace AppCircada.ViewModel;

public partial class QuizResultsViewModel : BaseViewModel
{
    QuizPageViewModel QuizPageVM;

    [ObservableProperty]
    int correctAnswers;

    [ObservableProperty]
    int numQuestions;

    [ObservableProperty]
    string resultMessage;

    QuizResultType quizResult;
    public QuizResultType QuizResult
    {
        get => quizResult;
        set => SetProperty(ref quizResult, value);
    }

    public QuizResultsViewModel(QuizPageViewModel quizPageVM)
    {
        QuizPageVM = quizPageVM;
        correctAnswers = QuizPageVM.QuizQuestions.Count(q => q.OptionReplies.Any(o => o.Reply == OptionReply.SelectedRight));
        numQuestions = QuizPageVM.QuizQuestions.Count;
        QuizResult = CalculateResult();
        SaveQuizResult();
    }

    private QuizResultType CalculateResult()
    {
        float ratio = (float)CorrectAnswers / (float)NumQuestions;
        QuizResultType result;
        if (ratio == 1f)
        {
            result = QuizResultType.Gold;
            ResultMessage = "¡Has obtenido el trofeo de oro! ¡Enhorabuena!";
        }
        else if (ratio >= 0.7f)
        {
            result = QuizResultType.Silver;
            ResultMessage = "¡Has obtenido el trofeo de plata! ¡Eres un experto!";
        }
        else if (ratio >= 0.5f)
        {
            result = QuizResultType.Bronze;
            ResultMessage = "¡Has obtenido el trofeo de bronce! ¡Ahora a por el de plata!";
        }
        else
        {
            result = QuizResultType.Sad;
            ResultMessage = "¡Sigue intentándolo para obtener un trofeo!";
        }

        return result;
    }

    private void SaveQuizResult()
    {
        var userScore = UserScoreService.GetUserScore();

        QuizType quizType;
        bool validQuizType = IsCurrentQuizAValidQuizType(out quizType);

        if (!validQuizType)
            return;

        userScore.ScoreDictionary.TryGetValue(quizType, out var savedScoreValue);
        if (QuizResult > savedScoreValue)
        {
            userScore.ScoreDictionary[quizType] = QuizResult;
            UserScoreService.SaveUserScore(userScore);
        }
    }

    private bool IsCurrentQuizAValidQuizType(out QuizType quizType)
    {
        quizType = new QuizType();
        bool isValid = false;
        if (NumQuestions == 10)
        {
            quizType = QuizType.AllQuestions10;
            isValid = true;
        }
        else if (NumQuestions == 15)
        {
            quizType = QuizType.AllQuestions15;
            isValid = true;
        }
        else if (NumQuestions == 20)
        {
            quizType = QuizType.AllQuestions20;
            isValid = true;
        }

        return isValid;
    }
}
