using GestAgro.Application.Interfaces;
using PhoneNumbers;

namespace GestAgro.Application.Services.Utils;

public partial class Utils
{
public bool TelephoneNumberValidation(string telephoneNumber, string region = "BR")
    {
        if (string.IsNullOrWhiteSpace(telephoneNumber))
        {
            return false;
        }

        var phoneUtil = PhoneNumberUtil.GetInstance();

        try
        {
            PhoneNumber parsedNumber = phoneUtil.Parse(telephoneNumber, region);

            return phoneUtil.IsValidNumber(parsedNumber);
        }
        catch (NumberParseException)
        {
            return false;
        }
    }
}