using Microsoft.VisualStudio.TestTools.UnitTesting;
using SedolAPI.BusinessLogicLayer;
using SedolAPI.BusinessLogicLayer.Interfaces;

namespace SedolAPI.Tests
{
    [TestClass]
    public abstract class SedolValidatorSpecs
    {
        private ISedolValidator _sedolValidator;

        [TestInitialize]
        public void Initilize()
        {
            _sedolValidator = new SedolValidator();
        }

        [TestClass]
        public class WhenInputValueIsInValid : SedolValidatorSpecs
        {
            [TestMethod]
            public void ThenTheSedoleValidtorReturnStringEmptyInvalidInputMessage()
            {
                var response = _sedolValidator.ValidateSedol(string.Empty);
                Assert.AreEqual("Input string was not 7-characters long", response.ValidationDetails);
                Assert.IsFalse(response.IsValidSedol);
                Assert.IsFalse(response.IsUserDefined);
            }

            [TestMethod]
            public void ThenTheSedoleValidtorReturnNullInvalidInputMessage()
            {
                var response = _sedolValidator.ValidateSedol(null);
                Assert.AreEqual("Input string was not 7-characters long", response.ValidationDetails);
                Assert.IsFalse(response.IsValidSedol);
                Assert.IsFalse(response.IsUserDefined);
            }

            [TestMethod]
            public void ThenTheSedoleValidtorReturnLessRequireLengthInvalidInputMessage()
            {
                var response = _sedolValidator.ValidateSedol("12");
                Assert.AreEqual("Input string was not 7-characters long", response.ValidationDetails);
                Assert.IsFalse(response.IsValidSedol);
                Assert.IsFalse(response.IsUserDefined);
            }

            [TestMethod]
            public void ThenTheSedoleValidtorReturnGreaterRequireLengthInvalidInputMessage()
            {
                var response = _sedolValidator.ValidateSedol("123456789");
                Assert.AreEqual("Input string was not 7-characters long", response.ValidationDetails);
                Assert.IsFalse(response.IsValidSedol);
                Assert.IsFalse(response.IsUserDefined);
            }
        }

        [TestClass]
        public class WhenInputValueIsInValidCharacters : SedolValidatorSpecs
        {
            [TestMethod]
            public void ThenTheSedoleValidtorReturnInValidCharacterInputMessage()
            {
                var response1 = _sedolValidator.ValidateSedol("9123_51");
                Assert.AreEqual("SEDOL contains invalid characters", response1.ValidationDetails);
                Assert.IsFalse(response1.IsValidSedol);
                Assert.IsFalse(response1.IsUserDefined);

                var response2 = _sedolValidator.ValidateSedol("VA.CDE8");
                Assert.AreEqual("SEDOL contains invalid characters", response2.ValidationDetails);
                Assert.IsFalse(response2.IsValidSedol);
                Assert.IsFalse(response2.IsUserDefined);
            }
        }

        [TestClass]
        public class WhenInValidCheckSumNonUserDefineSedol : SedolValidatorSpecs
        {
            [TestMethod]
            public void ThenTheSedoleValidtorReturnInValidCheckSumNonUserDefineSedolMessage()
            {
                var response = _sedolValidator.ValidateSedol("1234567");
                Assert.AreEqual("Checksum digit does not agree with the rest of the input", response.ValidationDetails);
                Assert.IsFalse(response.IsValidSedol);
                Assert.IsFalse(response.IsUserDefined);
            }
        }

        [TestClass]
        public class WhenInValidCheckSumUserDefineSedol : SedolValidatorSpecs
        {
            [TestMethod]
            public void ThenTheSedoleValidtorReturnInValidCheckSumUserDefineSedolMessage()
            {
                var response = _sedolValidator.ValidateSedol("9123451");
                Assert.AreEqual("Checksum digit does not agree with the rest of the input", response.ValidationDetails);
                Assert.IsTrue(response.IsUserDefined);
                Assert.IsFalse(response.IsValidSedol);

                var response2 = _sedolValidator.ValidateSedol("9ABCDE8");
                Assert.AreEqual("Checksum digit does not agree with the rest of the input", response2.ValidationDetails);
                Assert.IsTrue(response2.IsUserDefined);
                Assert.IsFalse(response2.IsValidSedol);
            }
        }

        [TestClass]
        public class WhenValidCheckSumNonUserDefineSedol : SedolValidatorSpecs
        {
            [TestMethod]
            public void ThenTheSedoleValidtorReturnValidCheckSumNonUserDefineSedolMessage()
            {
                var response = _sedolValidator.ValidateSedol("0709954");
                Assert.IsNull(response.ValidationDetails);
                Assert.IsFalse(response.IsUserDefined);
                Assert.IsTrue(response.IsValidSedol);

                var response2 = _sedolValidator.ValidateSedol("B0YBKJ7");
                Assert.IsNull(response2.ValidationDetails);
                Assert.IsFalse(response2.IsUserDefined);
                Assert.IsTrue(response2.IsValidSedol);
            }
        }

        [TestClass]
        public class WhenValidCheckSumUserDefineSedol : SedolValidatorSpecs
        {
            [TestMethod]
            public void ThenTheSedoleValidtorReturnValidCheckSumUserDefineSedolMessage()
            {
                var response = _sedolValidator.ValidateSedol("9123458");
                Assert.IsNull(response.ValidationDetails);
                Assert.IsTrue(response.IsUserDefined);
                Assert.IsTrue(response.IsValidSedol);

                var response2 = _sedolValidator.ValidateSedol("9ABCDE1");
                Assert.IsNull(response2.ValidationDetails);
                Assert.IsTrue(response2.IsUserDefined);
                Assert.IsTrue(response2.IsValidSedol);
            }
        }
    }
}