using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectHelper Create(ProjectData project)
        {
            manager.Navigator.GoProjectsPage();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        private List<ProjectData> projectList = new List<ProjectData>();

        public List<ProjectData> GetProjectList()
        {
            manager.Navigator.GoProjectsPage();
            projectList.Clear();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData()
                {
                    ProjectName = element.Text
                });
            }
            return projectList;

        }


        public ProjectHelper Remove(int p)
        {
            manager.Navigator.GoProjectsPage();
            SelectProject();
            RemoveProject();
            manager.Navigator.GoProjectsPage();

            return this;
        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }


        public ProjectHelper InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("//form[@action='manage_proj_create_page.php']//button")).Click();
            return this;
        }

        public ProjectHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.ProjectName);
            Type(By.Name("description"), project.Description);
            return this;

        }


        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return this;

        }


        public ProjectHelper SelectProject()
        {
            driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a[1]")).Click();
            return this;
        }

        public ProjectHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//fieldset/input[@type='submit']")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            return this;
        }

    }
}