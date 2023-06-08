using System;
using System.Text;

namespace _4_5_ExtensionMethodsSimple {
    public static class Extensions {
        // TODO: CamelCase hier als Extension-Method implementieren (Funktionalität für das Casing ist in "ToCamelCaseInternal" enthalten).
        public static string CamelCase(this string input)
        {
            return ToCamelCaseInternal(input);
        }
        
        // TODO: ToStringSafe hier als Extension-Method implementieren
        public static string ToStringSafe(this object input)
        {
            return input is null ? "null" : input.ToString();
        }

        private static string ToCamelCaseInternal(string s) {
            StringBuilder newString = new StringBuilder();
            bool sawUnderscore = false;

            foreach (char c in s) {
                if ((newString.Length == 0) && char.IsLetter(c)) {
                    newString.Append(char.ToUpper(c));
                } else if (c == '_') {
                    sawUnderscore = true;
                } else if (sawUnderscore) {
                    newString.Append(char.ToUpper(c));
                    sawUnderscore = false;
                } else {
                    newString.Append(char.ToLower(c));
                }
            }

            return newString.ToString();
        }
    }
}