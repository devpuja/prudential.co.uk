using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedolAPI.BusinessLogicLayer.Interfaces
{
    public interface ISedolValidator
    {
        /// <summary>
        /// Validates the SEDOL.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Instance of validation result.</returns>
        ISedolValidationResult ValidateSedol(string input);
    }
}