using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class TestProject : TestBase
    {
        AccountData account = new AccountData()
        {
            Username = "administrator",
            Password = "root",

        };

        ProjectData project = new ProjectData
        {
            ProjectName = "projectABC" + DateTime.Now.ToString(),
            Description = "descriptionXYZ"
        };



        [Test]
        public void CreateProjectTest()
        {


            var oldProjects = app.API.GetProjectsList(account);

            app.Auth.Login(account);
            app.Navigator.GoProjectsPage();
            app.Projects.Create(project);

            var newProjects = app.API.GetProjectsList(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }

        [Test]
        public void RemoveProjectTest()
        {

            var projectsList = app.API.GetProjectsList(account);
            if (projectsList.Count == 0)
            {
                app.API.CreateProject(account, project);
            }
            var oldProjects = app.API.GetProjectsList(account);
            app.Auth.Login(account);
            app.Navigator.GoProjectsPage();

            app.Projects.Remove(1);
            var newProjects = app.API.GetProjectsList(account);

            oldProjects.Remove(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}