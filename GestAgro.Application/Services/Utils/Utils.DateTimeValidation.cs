using System.Globalization;

namespace GestAgro.Application.Services.Utils;

public partial class Utils
{
    public bool DateTimeValidation(string dateString)
    {
        if (string.IsNullOrWhiteSpace(dateString))
        {
            return false;
        }

        string[] formats = {
            "dd/MM/yyyy",
            "d/M/yyyy",
            "yyyy-MM-dd",
            "dd-MM-yyyy",
            "dd/MM/yyyy HH:mm:ss"
        };

        return DateTime.TryParseExact(
            s: dateString,     
            formats: formats,   
            provider: CultureInfo.InvariantCulture,
            style: DateTimeStyles.None, 
            result: out _ 
        );
    }
}