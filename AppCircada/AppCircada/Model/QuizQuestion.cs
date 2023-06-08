namespace AppCircada.Model;

public class QuizQuestion
{
    public string question { get; set; }
    public string[] options { get; set; }
    public int answer { get; set; }
    public string picture { get; set; }

    public QuizQuestion DeepCopy()
    {
        var copy = this.MemberwiseClone() as QuizQuestion;
        copy.options = new string[options.Length];
        for (int i = 0; i < options.Length; i++)
            copy.options[i] = options[i].ToString();
        return copy;
    }
}