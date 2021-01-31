using SedolAPI.BusinessLogicLayer.Interfaces;
using SedolAPI.Utilities;
using System;

namespace SedolAPI.BusinessLogicLayer
{
    public class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string sedolValue)
        {
            if (string.IsNullOrEmpty(sedolValue) || sedolValue.IsInValid())
            {
                return new SedolValidationResult(sedolValue, false, false, "Input string was not 7-characters long");
            }

            if (sedolValue.IsFormatInValid())
            {
                return new SedolValidationResult(sedolValue, false, false, "SEDOL contains invalid characters");
            }

            int checkSumValue = 0;
            for (int i = 0; i < sedolValue.Length - 1; i++)
            {
                var weightValue = sedolValue[i].IsChar() ? sedolValue[i].GetCharValue() : Convert.ToInt32(sedolValue[i].ToString());
                checkSumValue += Helper.GetCheckSumValue(i, weightValue);
            }

            int checkDigitValue = Helper.GetCheckDigitValue(checkSumValue);
            bool isValidSedol = checkDigitValue == Convert.ToInt32(sedolValue[sedolValue.Length - 1].ToString());
            string message = isValidSedol ? null : "Checksum digit does not agree with the rest of the input";

            return new SedolValidationResult(sedolValue, isValidSedol, sedolValue[0].IsUserdefined(), message);
        }
    }
}