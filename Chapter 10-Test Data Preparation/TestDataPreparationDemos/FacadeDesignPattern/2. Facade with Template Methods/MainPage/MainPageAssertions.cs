using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDataPreparationDemos.Facades.Second
{
    public class MainPageAssertions
    {
        private readonly MainPageElements _elements;

        public MainPageAssertions(MainPageElements elements)
        {
            _elements = elements;
        }

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _elements.GetProductBoxByName(name).GetAttribute("href");
            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
