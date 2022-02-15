using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.25.2")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.25.2");
        }
        public void GoProjectsPage()
        {
            if (driver.Url == baseURL + "/mantisbt-2.25.2/manage_proj_page.php")
            {
                return;
            }
            driver.FindElement(By.XPath("//i[@class = 'fa fa-gears menu-icon']")).Click();
            driver.FindElement(By.XPath("//a[@href = '/mantisbt-2.25.2/manage_proj_page.php']")).Click();
        }
    }
}