using GestAgro.Application.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GestAgro.Application.Services.Utils;

public partial class Utils
{
    public bool EletronicAdressValidation(string eletronicAdress)
    {
        if (string.IsNullOrWhiteSpace(eletronicAdress))
        {
            return false;
        }

        try
        {
            eletronicAdress = Regex.Replace(eletronicAdress, @"(@)(.+)$",
                match => match.Groups[1].Value + match.Groups[2].Value.ToLowerInvariant(),
                RegexOptions.None, TimeSpan.FromMilliseconds(250));

            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(eletronicAdress, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}