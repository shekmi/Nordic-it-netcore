using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory.Test
{
    [TestClass]
    public class InMemoryReminderStorageTest
    {
        [TestMethod]
        public void Method_Add_With_Not_Null_Item_Should_Store_The_Item_Iternally()
        {
            //prepare test data
            var storage = new InMemoryReminderStorage();
            var expected = new ReminderItem(
                Guid.NewGuid(),
                "TelegramContactID",
                DateTimeOffset.Now,
                "Hello World ><");

            //do the test
            storage.Add(expected);

            //check the results
            var actual = storage.Get(expected.Id);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.ContactId, actual.ContactId);
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Date, actual.Date);
        }

        [TestMethod]
        public void Method_Get_By_Id_Should_Return_Null_For_Empty_Storage()
        {
            //prepare test data
            var storage = new InMemoryReminderStorage();
            //do the test
            var actual = storage.Get(Guid.Empty);
            //check the result
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Method_Get_By_Id_Should_Return_Not_Null_For_Existing_Item_Internal()
        {
            //prepare test data
            var storage = new InMemoryReminderStorage();
            var expected = new ReminderItem(
                Guid.NewGuid(),
                "TelegramContactID",
                DateTimeOffset.Now,
                "Hello World ><");
            storage.Storage.Add(expected.Id, expected);
            //do the test
            var actual = storage.Get(expected.Id);
            //check the result
            Assert.IsNotNull(actual);
        }
    }
}
