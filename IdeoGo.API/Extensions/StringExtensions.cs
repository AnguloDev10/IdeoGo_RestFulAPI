using System.Linq;

namespace IdeoGo.API.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
                                                         //si es mayuscula     enotnces pasa a _                    //Toda la sentencia a tolower
        }
    }
}
