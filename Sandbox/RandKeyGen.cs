using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public static class RandKeyGen
    {
        #region Private
        private const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        private const string digitChars = "01234567890123456789";
        #endregion

        public static string Generate(int bitdepth = 64, GenFlags flags = GenFlags.LOWER_CH | GenFlags.DIGIT_CH)
        {
            string source = null;

            switch ((int)flags)
            {
                case 1:
                    source = upperChars;
                    break;
                case 2:
                    source = lowerChars;
                    break;
                case 3:
                    source = upperChars + lowerChars;
                    break;
                case 4:
                    source = digitChars;
                    break;
                case 5:
                    source = upperChars + digitChars;
                    break;
                case 6:
                    source = lowerChars + digitChars;
                    break;
                case 7:
                    source = upperChars + lowerChars + digitChars;
                    break;
                default:
                    break;
            }

            int length = bitdepth / 8;
            StringBuilder builder = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                builder.Append(source[random.Next(0, source.Length)]);
            }

            return builder.ToString();
        }

        public enum GenFlags
        {
            UPPER_CH = 1,
            LOWER_CH = 2,
            DIGIT_CH = 4,
        }
    }
}
