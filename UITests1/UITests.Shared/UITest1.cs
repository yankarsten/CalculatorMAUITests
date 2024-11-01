using NUnit.Framework;

// You will have to make sure that all the namespaces match
// between the different platform specific projects and the shared
// code files. This has to do with how we initialize the AppiumDriver
// through the AppiumSetup.cs files and NUnit SetUpFixture attributes.
// Also see: https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html
namespace UITests
{
    // This is an example of tests that do not need anything platform specific.
    // Typically you will want all your tests to be in the shared project so they are ran across all platforms.
    public class UITest1 : BaseTest
    {
        [Test]
        public void TestBasicAddition()
        {
            FindUIElement("Btn_1").Click();
            FindUIElement("Btn_Plus").Click();
            FindUIElement("Btn_2").Click();
            FindUIElement("Btn_Equals").Click();

            string resultText = FindUIElement("resultText").Text;
            bool isResultTrue = resultText == "3";
            Assert.That(isResultTrue, resultText, "1 + 2 should equal 3");
        }

        [Test]
        public void TestBasicSubtraction()
        {
            FindUIElement("Btn_2").Click();
            FindUIElement("Btn_Minus").Click();
            FindUIElement("Btn_1").Click();
            FindUIElement("Btn_Equals").Click();

            string resultText = FindUIElement("resultText").Text;
            bool isResultTrue = resultText == "1";
            Assert.That(isResultTrue, resultText, "2 - 1 should equal 1");
        }

        [Test]
        public void TestRandomAddition()
        {
            Random r = new Random();
            int n1 = r.Next(0, 9);
            int n2 = r.Next(0, 9);
            FindUIElement($"Btn_{n1}").Click();
            FindUIElement("Btn_Plus").Click();
            FindUIElement($"Btn_{n2}").Click();
            FindUIElement("Btn_Equals").Click();

            string resultText = FindUIElement("resultText").Text;
            bool isResultTrue = resultText == (n1 + n2).ToString();
            Assert.That(isResultTrue, resultText, $"{n1} + {n2} should equal {n1 + n2}");
        }
        [Test]
        public void TestRandomSubtraction()
        {
            Random r = new Random();
            int n1 = r.Next(0, 9);
            int n2 = r.Next(0, 9);
            FindUIElement($"Btn_{n1}").Click();
            FindUIElement("Btn_Minus").Click();
            FindUIElement($"Btn_{n2}").Click();
            FindUIElement("Btn_Equals").Click();

            string resultText = FindUIElement("resultText").Text;
            bool isResultTrue = resultText == (n1 - n2).ToString();
            Assert.That(isResultTrue, resultText, $"{n1} - {n2} should equal {n1 - n2}");
        }
        [Test]
        public void TestRandomMultiplication()
        {
            Random r = new Random();
            int n1 = r.Next(0, 9);
            int n2 = r.Next(0, 9);
            FindUIElement($"Btn_{n1}").Click();
            FindUIElement("Btn_Multiply").Click();
            FindUIElement($"Btn_{n2}").Click();
            FindUIElement("Btn_Equals").Click();

            string resultText = FindUIElement("resultText").Text;
            bool isResultTrue = resultText == (n1 * n2).ToString();
            Assert.That(isResultTrue, resultText, $"{n1} * {n2} should equal {n1 * n2}");
        }

        [Test]
        public void TestRandomDivision()
        {
            Random r = new Random();
            int n1 = r.Next(0, 9);
            int n2 = r.Next(0, 9);
            FindUIElement($"Btn_{n1}").Click();
            FindUIElement("Btn_Divide").Click();
            FindUIElement($"Btn_{n2}").Click();
            FindUIElement("Btn_Equals").Click();

            string resultText = FindUIElement("resultText").Text;
            bool isResultTrue = resultText == ((double)(n1 / n2)).ToString();
            Assert.That(isResultTrue, resultText, $"{n1} / {n2} should equal {(double)(n1 / n2)}");
        }

        [Test]
        public void TestRandomBigNumberAddition()
        {
            Random r = new Random();

            int n1 = r.Next(1000, 99999);
            int n2 = r.Next(1000, 99999);


            string s1 = n1.ToString();
            string s2 = n2.ToString();

            foreach (char c in s1)
            {
                FindUIElement($"Btn_{c}").Click();
            }
            FindUIElement($"Btn_Plus").Click();

            foreach (char c in s2)
            {
                FindUIElement($"Btn_{c}").Click();
            }
            FindUIElement("Btn_Equals").Click();

            string resultText = FindUIElement("resultText").Text.Replace(",", string.Empty);
            bool isResultTrue = resultText == (n1+n2).ToString();
            Assert.That(isResultTrue, resultText, $"{n1} + {n2} should equal {n1+n2}");
        }
    }
}