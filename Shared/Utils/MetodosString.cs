using System.ComponentModel;

namespace Shared.Utils
{
    public static class MetodosString
    {
        public static bool Compara(string string1, string string2, bool ignoraSensitiveCase)
        {
            return string.Equals(string1, string2, ignoraSensitiveCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}
