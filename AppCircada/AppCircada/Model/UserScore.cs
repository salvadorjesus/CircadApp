namespace AppCircada.Model;

public class UserScore
{
    public Dictionary<QuizType, QuizResultType> ScoreDictionary { get; set; }

    public UserScore()
    {
        ScoreDictionary = new Dictionary<QuizType, QuizResultType>();
    }
}
