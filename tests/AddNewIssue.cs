using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTest : TestBase
    {
        [Test]

        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Username = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                ID = "19"
            };

            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"

            };
            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
