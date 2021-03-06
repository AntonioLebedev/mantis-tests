
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]

        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
                
        }
        

        [Test]
        public void TestAccountRegistration()
        {

            AccountData account = new AccountData()
            {
                Username = "testuser8",
                Password = "password",
                Email = "testuser8@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();

            AccountData existingAccount = accounts.Find(x => x.Username == account.Username);

            if(existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }

        [TearDown]

        public void restoreConfig()
        {
            app.Ftp.RestoreBackUpFile("/config_inc.php");
        }
    }
}
