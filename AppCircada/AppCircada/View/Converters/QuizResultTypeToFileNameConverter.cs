using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCircada.View.Converters;

public class QuizResultTypeToFileNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string returnString = "";

        if (value is QuizResultType resultType)
        {
            switch (resultType)
            {
                case QuizResultType.Sad:
                    returnString = "sad.json";
                    break;
                case QuizResultType.Bronze:
                    returnString = "bronze.json";
                    break;
                case QuizResultType.Silver:
                    returnString = "silver.json";
                    break;
                case QuizResultType.Gold:
                    returnString = "gold.json";
                    break;
            }
        }
        return returnString;
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
