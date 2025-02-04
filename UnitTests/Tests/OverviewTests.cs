using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBDApp.Business;
using IBDApp.ViewModels;

namespace UnitTests.Tests
{
    public class OverviewTests : IClassFixture<MAUIAppProvider>
    {
        private readonly MAUIAppProvider _appProvider;
        private readonly OverviewViewModel _overviewViewModel;

        public OverviewTests(MAUIAppProvider MAUIAppProvider) {
            _appProvider = MAUIAppProvider;
            _overviewViewModel = _appProvider.MauiApp.Services.GetService<OverviewViewModel>();
        }

        [Theory]
        [InlineData("", "No description yet")]
        [InlineData("abcde", "abcde")]
        [InlineData("Longer type of description", "Longer type of description")]
        public void FormatDescriptionWithLessThanFiveChar(string description, string expectedDescription)
        {
            //Arrange

            //Act
            description = _overviewViewModel.OverviewDomainService.FormatDescription(description);

            //Assert
            Assert.Equal(expectedDescription, description);

        }
    }
}
