using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace projectChallenge.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            for (int i = 0; i < 10; i++)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://localhost:5000/");
                //driver.Manage().Window.Maximize();
                //System.Threading.Thread.Sleep(3000);
                IWebElement element = driver.FindElement(By.LinkText("Sing In >"));
                element.Click();
                element = driver.FindElement(By.Id("username"));
                element.SendKeys("123");
                element = driver.FindElement(By.Id("password"));
                element.SendKeys("123");
                // System.Threading.Thread.Sleep(3000);
                element.Submit();
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
        }
    }
}
