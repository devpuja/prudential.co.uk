using SedolAPI.BusinessLogicLayer.Interfaces;

namespace SedolAPI.BusinessLogicLayer
{
    public class SedolValidationResult : ISedolValidationResult
    {
        private readonly string _InputString;
        private readonly bool _IsValidSedol;
        private readonly bool _IsUserDefined;
        private readonly string _ValidationDetails;

        public SedolValidationResult(string InputString, bool IsValidSedol, bool IsUserDefined, string ValidationDetails)
        {
            _InputString = InputString;
            _IsValidSedol = IsValidSedol;
            _IsUserDefined = IsUserDefined;
            _ValidationDetails = ValidationDetails;
        }

        public string InputString
        {
            get => _InputString;
        }

        public bool IsValidSedol
        {
            get => _IsValidSedol;
        }

        public bool IsUserDefined
        {
            get => _IsUserDefined;
        }

        public string ValidationDetails
        {
            get => _ValidationDetails;
        }
    }
}