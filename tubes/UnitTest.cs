using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CERDIK;
using Xamarin.Forms;

namespace HelpCenterTests
{
    [TestClass]
    public class HelpCenterTests
    {
        private HelpCenter _helpCenter;

        [TestInitialize]
        public void Setup()
        {
            _helpCenter = new HelpCenter
            {
                ConnectionString = "Your Connection String Here"
            };
        }

        [TestMethod]
        public void TestGetHelpCenterData()
        {
            var data = _helpCenter.GetHelpCenterData();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestSearchHelpCenter()
        {
            var data = _helpCenter.GetHelpCenterData();
            var firstQuestion = data.First().Question;
            var results = data.Where(x => x.Question.Contains(firstQuestion) || x.Answer.Contains(firstQuestion));
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public void TestAddHelpCenterEntry()
        {
            int initialCount = _helpCenter.GetHelpCenterData().Count;

            _helpCenter.AddHelpCenterEntry();

            int finalCount = _helpCenter.GetHelpCenterData().Count;

            Assert.IsTrue(finalCount > initialCount);
        }
    }
}
