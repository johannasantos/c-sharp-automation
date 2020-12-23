using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace automationExercise
{
    class searchBing
    {
        ChromeDriver driver = new ChromeDriver();
        
        IWebElement findElementWait(By selector) {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            return wait.Until(e => e.FindElement(selector));
        }
        
        static void Main(string[] args)
        {
            searchBing sb = new searchBing();
            // Navigate to Bing
            sb.driver.Url = "https://www.bing.com/";
            // Maximize window
            var window = sb.driver.Manage().Window;
            window.Maximize();

            // Identify location of search element
            IWebElement searchInput = sb.findElementWait(By.Id("sb_form_q"));
            // search for "covid" 
            searchInput.SendKeys("covid" + Keys.Enter);
            
            // find second result and open the website
            IWebElement secondResult = sb.findElementWait(By.XPath("//ol[@id=\"b_results\"]/li[2]//h2"));
            secondResult.Click();
            
            // Create a text file with the current URL and save it to a txt file
            File.WriteAllText("test.txt", sb.driver.Url);  

            sb.driver.Close();
        }
    }
}
