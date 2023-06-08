using System.Text.Json;
using System.IO;

namespace AppCircada.Services;

public static class UserScoreService
{
    const string FILE_NAME = "UserScore.json";
    static string FilePath = FileSystem.AppDataDirectory + "/" + FILE_NAME;
    public static UserScore GetUserScore()
    {
        UserScore returnScore;
        
        try
        {
            var rawData = File.ReadAllText(FilePath);
            returnScore = JsonSerializer.Deserialize<UserScore>(rawData);
        }
        catch (FileNotFoundException)
        {
            returnScore = new UserScore();
        }

        return returnScore;
    }

    public static void SaveUserScore(UserScore userScore)
    {
        var serializedData = JsonSerializer.Serialize(userScore);
        File.WriteAllText(FilePath, serializedData);
    }

    public static void ClearUserScore()
    {
        SaveUserScore(new UserScore());
    }
}
