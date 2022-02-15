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


            app.Auth.Login(account);
            app.Navigator.GoProjectsPage();

            List<ProjectData> oldProjects = app.Projects.GetProjectList();
            app.Projects.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectList().Count);

            List<ProjectData> newProjects = app.Projects.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }

        [Test]
        public void RemoveProjectTest()
        {

            app.Auth.Login(account);
            app.Navigator.GoProjectsPage();

            List<ProjectData> projectsList = app.Projects.GetProjectList();
            if (projectsList.Count == 0)
            {
                app.Projects.Create(project);
            }

            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.Remove(1);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectList().Count);

            List<ProjectData> newProjects = app.Projects.GetProjectList();
            oldProjects.Remove(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}