using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace WebJob1
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        private static IWebDriver _browser;

        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var host = new JobHost();
            Program test = new Program();

            //Test Steps
            test.SetUp();
            test.FindBlogLinkFromNavigationAndClickIt();
            test.CountArticles();

            //Quit
            _browser.Quit();
            host.Dispose();


            // The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();
        }

        private void CountArticles()
        {
            var articles = _browser.FindElements(By.TagName("article"));
            Console.WriteLine("There are: " + articles.Count.ToString() + "articles");
        }

        private void FindBlogLinkFromNavigationAndClickIt()
        {
            _browser.Navigate().GoToUrl("http://nultien.rs/");
            var blogLink = _browser.FindElement(By.LinkText("BLOG"));
            blogLink.Click();
        }

        private void SetUp()
        {
            //Set Capabilities
            DesiredCapabilities capability = DesiredCapabilities.Safari();
            capability.SetCapability("browserstack.user", "leandroribeiro5");
            capability.SetCapability("browserstack.key", "DegnBRqhCN3uMqdoLxSm");
            capability.SetCapability("build", "First build");
            capability.SetCapability("browserstack.debug", "true");

            capability.SetCapability("browser", "Safari");
            capability.SetCapability("browser_version", "9.0");
            capability.SetCapability("os", "OS X");
            capability.SetCapability("os_version", "El Capitan");
            capability.SetCapability("resolution", "1600x1200");

            _browser = new RemoteWebDriver(
                new Uri("http://hub.browserstack.com/wd/hub/"), capability
            );
        }
    }
}
