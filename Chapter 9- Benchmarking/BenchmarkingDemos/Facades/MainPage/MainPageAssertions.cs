using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BenchmarkingDemos.Facades.Second
{
    public class MainPageAssertions
    {
        private readonly MainPageElements _elements;

        public MainPageAssertions(MainPageElements pageElements)
        {
            _elements = pageElements;
        }

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _elements.GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
