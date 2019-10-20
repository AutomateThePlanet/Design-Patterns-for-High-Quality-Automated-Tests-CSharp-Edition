using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUsabilityDemos.Facades.Second
{
    public class MainPageAssertions
    {
        private readonly MainPageElements _pageElements;

        public MainPageAssertions(MainPageElements pageElements) => _pageElements = pageElements;

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _pageElements.GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
