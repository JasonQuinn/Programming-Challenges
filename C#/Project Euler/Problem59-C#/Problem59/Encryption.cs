using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem59
{
    class Encryption
    {
        private char[] Key { get; set; }
        private readonly char[] _lowerCaseChars = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private IEnumerable<char> File { get; set; }

        public Encryption(IEnumerable<char> file)
        {
            File = file;
        }

        public int TryToUnencrypt()
        {
            foreach (var lowerCaseChar1 in _lowerCaseChars)
            {
                foreach (var lowerCaseChar2 in _lowerCaseChars)
                {
                    foreach (var lowerCaseChar3 in _lowerCaseChars)
                    {
                        Key = new[] { lowerCaseChar1, lowerCaseChar2, lowerCaseChar3 };
                        var value = UnEncrypt();
                        //checking for common words
                        if (!string.IsNullOrWhiteSpace(value) && value.IndexOf("and", StringComparison.OrdinalIgnoreCase) >= 0 && value.IndexOf("the", StringComparison.OrdinalIgnoreCase) >= 0
                            && value.IndexOf("be", StringComparison.OrdinalIgnoreCase) >= 0 && value.IndexOf("of", StringComparison.OrdinalIgnoreCase) >= 0
                            && value.IndexOf("that", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            return value.Sum(u => u);
                        }
                    }
                }
            }
            return -1;
        }

        private string UnEncrypt()
        {
            var unencrypterFile = new List<char>();
            foreach (var encryptedChar in File)
            {
                var unencryptedChar = encryptedChar ^ GetCurrentKey();
                if (IsAscii(unencryptedChar))
                {
                    unencrypterFile.Add(Convert.ToChar(unencryptedChar));
                }
                else
                {
                    return string.Empty;
                }
            }
            return new string(unencrypterFile.ToArray());
        }

        private char GetCurrentKey()
        {
            var ch = Key.ElementAt(0);
            Key = new[] { Key.ElementAt(1), Key.ElementAt(2), Key.ElementAt(0) };
            return ch;
        }

        private static bool IsAscii(int character)
        {
            return character >= 32 && character <= 127;
        }
    }
}
