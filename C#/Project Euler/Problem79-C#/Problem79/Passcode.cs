using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem79
{
    public class Passcode
    {
        public IEnumerable<string> Passcodes { get; private set; }
        private List<char> DistinctNumbers { get; set; }
        public int LowestPossibleNum { get; private set; }

        public Passcode(IEnumerable<string> passcodes)
        {
            Passcodes = passcodes;
            DistinctNumbers = new List<char>();
            foreach (var charNum in passcodes.SelectMany(passcode => passcode))
            {
                DistinctNumbers.Add(charNum);
            }
            DistinctNumbers = DistinctNumbers.Distinct().ToList();
            DistinctNumbers.Sort();
            LowestPossibleNum = int.Parse(new string(DistinctNumbers.ToArray()));
        }

        public bool CheckIfNumberWorks(BigInteger number)
        {
            if (DistinctNumbers.Any(distinctNumber => !number.ToString().Contains(distinctNumber)))
            {
                return false;
            }
            foreach (var passcode in Passcodes)
            {
                var numberString = number.ToString();
                foreach (var passcodeChar in passcode)
                {
                    var position = numberString.IndexOf(passcodeChar);
                    if (position == -1)
                    {
                        return false;
                    }
                    if (position < numberString.Length)
                    {
                        numberString = numberString.Substring(position);
                    }
                }
            }
            return true;
        }
    }
}
