using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyDAL.Models;

namespace StudyWPF.Test
{
    [TestClass]
    public class EntryTests
    {
        [TestMethod]
        public void Entry_Returns_String()
        {
            //  Arrange
            Entry entry = new Entry() { Subject = "C#", Duration = new TimeSpan(2, 30, 0), DateTimeStamp = DateTime.Now.AddHours(1) };
            string expected = $"Id: {entry.EntryID}\tSubject: {entry.Subject}\tDuration: {entry.Duration.ToString()}\tDTS: {entry.DateTimeStamp.ToString()}";

            //  Act
            string result = entry.ToString();

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_Method_2()
        {
            //  Arrange
            

            //  Act
           

            //  Assert
            
        }
    }
}
