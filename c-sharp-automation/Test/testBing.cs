using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace automationExercise
{
    class searchBing
    {
        static void Main(string[] args)
        {
            ChromeDriver driver = new ChromeDriver();
            // Navigate to Bing
            driver.Url = "https://www.bing.com/";

            // Maximize window
            var window = driver.Manage().Window;
            window.Maximize();

            // Identify location of search element
            IWebElement searchInput = driver.FindElement(By.Id("sb_form_q"));
            // search for "covid" 
            searchInput.SendKeys("covid" + Keys.Enter);
            // find second result and open the website
            IWebElement secondResult = driver.FindElement(By.XPath("//ol[@id=\"b_results\"]/li[2]//h2"));
            secondResult.Click();
            // Create a text file with the current URL and save it to a txt file
            File.WriteAllText("test.txt", driver.Url);  

            driver.Close();
            
            
        }
    }
}
