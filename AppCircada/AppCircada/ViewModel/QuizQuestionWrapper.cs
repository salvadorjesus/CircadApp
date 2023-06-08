namespace AppCircada.ViewModel;

/// <summary>
/// This class warps the QuizQuestion class from model and add functionality and observable properties for the view to display.
/// In the view, a CollectionView or similar would/does presents a List of QuizQuestionWrapper provided by the page/view viewModel.
/// </summary>
public partial class QuizQuestionWrapper : ObservableObject
{
    public QuizQuestion QuizQuestion;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AnswerQuestionCommand))]
    bool questionUnasnwered = true;

    /* Options must be its own list. It cannot just returns QuizQuestion.options:
    public string[] Options => QuizQuestion.options;
    That would work in Android in debug mode, but fail on release with a Java’s System.NotSuchMethodException
     */
    [ObservableProperty]
    List<string> options = new();
    
    [ObservableProperty]
    List<ObservableOptionReply> optionReplies = new();

    [ObservableProperty]
    List<ObservableStyle> buttonsStyle = new();

    Style ButtonCorrectStyle;
    Style ButtonWrongStyle;
    public string Question => QuizQuestion.question;
    public int Answer => QuizQuestion.answer - 1;
    public string Picture => "quiz/"+QuizQuestion.picture;
    public bool HasPicture => !String.IsNullOrEmpty(QuizQuestion.picture);

    public QuizQuestionWrapper(QuizQuestion question)
    {
        QuizQuestion = question;

        var buttonDefaultStyle = Application.Current.Resources.MergedDictionaries.ToList()[1]["QuizButton"] as Style;
        ButtonCorrectStyle = Application.Current.Resources.MergedDictionaries.ToList()[1]["QuizButtonCorrect"] as Style;
        ButtonWrongStyle = Application.Current.Resources.MergedDictionaries.ToList()[1]["QuizButtonWrong"] as Style;
        for (int i = 0; i < question.options.Length; i++)
        {
            ButtonsStyle.Add(new ObservableStyle(buttonDefaultStyle));
            Options.Add(question.options[i]);
            OptionReplies.Add(new ObservableOptionReply(OptionReply.Unselected));
        }
    }

    [RelayCommand(CanExecute = nameof(QuestionUnasnwered))]
    void AnswerQuestion(int answer)
    {
        ButtonsStyle[answer].Style = Answer == answer ? ButtonCorrectStyle : ButtonWrongStyle;
        OptionReplies[answer].Reply = Answer == answer ? OptionReply.SelectedRight : OptionReply.SelectedWrong;
        //Question unanswered will trigger the jump of the Quiz Result Page.
        //Thus, it has to be the last property to modify in the function.
        QuestionUnasnwered = false;
    }
}

/*I have decided to write the following classes here, given how closely coupled are to the main
 * class QuizQuestionWrapper. Writing them on their own file could seem tidier, but would be
 * confusing for someone trying to understand the project structure for the first time.*/
public enum OptionReply { Unselected, SelectedWrong, SelectedRight }

public partial class ObservableStyle : ObservableObject
{
    [ObservableProperty]
    Style style;

    public ObservableStyle (Style style)
    {
        this.style = style;
    }
}

public partial class ObservableOptionReply : ObservableObject
{
    [ObservableProperty]
    OptionReply reply;

    public ObservableOptionReply(OptionReply reply)
    {
        this.reply = reply;
    }
}