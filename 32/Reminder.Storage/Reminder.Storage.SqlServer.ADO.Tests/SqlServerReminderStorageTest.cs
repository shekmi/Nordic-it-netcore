using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    [TestClass]
    public class SqlServerReminderStorageTest
    {
      
           [ClassInitialize]
        public static void ClassInitialize()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnection 
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
}
