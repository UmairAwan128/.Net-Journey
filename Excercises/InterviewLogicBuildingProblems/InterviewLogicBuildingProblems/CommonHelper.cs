using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLogicBuildingProblems
{
    public static class CommonHelpers
    {
        public static string PadOrCropRight(this string str, int totalLength, char paddingChar)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty.PadRightWithNullCheck(totalLength, paddingChar);
            if (str.Length > totalLength)
            {
                return str.Substring(0, totalLength);
            }
            return str.PadRightWithNullCheck(totalLength, paddingChar);
        }

        public static string PadRightWithNullCheck(this string str, int totalWith, char paddingChar)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty.PadRight(totalWith, paddingChar);
            return str.PadRight(totalWith, paddingChar);
        }
    }
}
