using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBDApp.Business;

namespace UnitTests.Tests
{
    public class OverviewTests
    {
        private readonly OverviewDomainService _overviewDomainService;

        public OverviewTests() { 
            _overviewDomainService = new OverviewDomainService();
        }

        [Theory]
        [InlineData("", "No description yet")]
        [InlineData("abcde", "abcde")]
        [InlineData("Longer type of description", "Longer type of description")]
        public void FormatDescriptionWithLessThanFiveChar(string description, string expectedDescription)
        {
            //Arrange - we use the params

            //Act
            description = _overviewDomainService.FormatDescription(description);

            //Assert
            Assert.Equal(expectedDescription, description);

        }
    }
}
