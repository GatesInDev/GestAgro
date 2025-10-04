using System.ComponentModel.DataAnnotations;

namespace GestAgro.Application.Interfaces;

public interface IUtils
{
    #region Verifiers

    public bool EletronicAdressValidation(string email);

    public bool TelephoneNumberValidation(string telephoneNumber, string region);

    public bool DateTimeValidation(string datetime);

    #endregion
}