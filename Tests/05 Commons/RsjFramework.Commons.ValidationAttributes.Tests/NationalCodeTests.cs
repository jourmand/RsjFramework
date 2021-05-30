using Xunit;

namespace RsjFramework.Commons.ValidationAttributes.Tests
{
    public class NationalCodeTests
    {
     
        [Theory]
        [InlineData("0607907703")]
        [InlineData("0594163544")]
        [InlineData("0005063000")]
        [InlineData("0076608123")]
        public void is_natioanl_code_valid(string nationalCode)
        {
            var validation = new NationalCodeAttribute();
            var isValid = validation.IsValid(nationalCode);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("14002692875")]
        [InlineData("10102425969")]
        [InlineData("14005820452")]
        [InlineData("14004334449")]
        public void is_legal_code_valid(string nationalCode)
        {
            var validation = new NationalCodeAttribute(IsCompanyNationalCode: true);
            var isValid = validation.IsValid(nationalCode);
            Assert.True(isValid);
        }

    }
}
