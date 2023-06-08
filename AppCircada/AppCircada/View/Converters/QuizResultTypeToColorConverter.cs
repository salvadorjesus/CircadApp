using System.Globalization;
using Microsoft.Maui.Graphics;

namespace AppCircada.View.Converters;

public class QuizResultTypeToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string colorKey = "Gray500";

        if (value is QuizResultType resultType)
        {
            switch (resultType)
            {
                case QuizResultType.Sad:
                    var appTheme = App.Current.RequestedTheme;
                    if (appTheme == AppTheme.Light || appTheme == AppTheme.Unspecified)
                        colorKey = "NoTrophyLight";
                    else
                        colorKey = "NoTrophyDark";
                    break;
                case QuizResultType.Bronze:
                    colorKey = "TrophyBronze";
                    break;
                case QuizResultType.Silver:
                    colorKey = "TrophySilver";
                    break;
                case QuizResultType.Gold:
                    colorKey = "TrophyGold";
                    break;
            }
        }
        if (App.Current.Resources.MergedDictionaries.ToList()[1].TryGetValue(colorKey, out var colorvalue))
            return colorvalue;
        else
            return new Color(0, 0, 0);
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
