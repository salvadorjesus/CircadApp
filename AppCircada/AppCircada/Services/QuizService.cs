namespace AppCircada.Services;

public static class QuizService
{
    static List<QuizQuestion> QuizList;

    public static async Task<List<QuizQuestion>> GetQuizAsync(int numQuestions, bool shuffle = true)
    {
        List<QuizQuestion> returnList;
        if (QuizList == null)
            await ReadQuizListAsync();

        returnList = QuizList.ConvertAll(question => question.DeepCopy());//new List<QuizQuestion>(QuizList);

        while (returnList.Count < numQuestions)
        {   //Pass copies of que questions so that the views that bind to their options don't
            //exhibit unpredictable behavior.
            returnList.AddRange(QuizList.ConvertAll(question => question.DeepCopy()));
        }

        if (shuffle)
        {
            var rand = new Random();
            returnList = returnList.OrderBy(x => rand.Next()).ToList();
        }

        return returnList.GetRange(0,numQuestions);
    }

    static async Task ReadQuizListAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quiz.test.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        QuizList = JsonSerializer.Deserialize<List<QuizQuestion>>(contents);
    }
}
