using System.ComponentModel;

namespace GestAgro.Application.Extensions.EnumExtensions
{

    /// <summary>
    /// Classe estática para métodos de extensão de Enums.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Obtém o valor do atributo [Description] de um membro do Enum.
        /// </summary>
        /// <param name="value">O valor do Enum.</param>
        /// <returns>A string definida no atributo [Description], ou o nome do membro se o atributo não existir.</returns>
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();

            var name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            var field = type.GetField(name);
            if (field == null)
            {
                return name;
            }

            var attr = (DescriptionAttribute?)Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute));

            return attr != null ? attr.Description : name;
        }
    }
}
