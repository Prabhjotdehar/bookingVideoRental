using Microsoft.VisualStudio.TestTools.UnitTesting;
using bookingVideoRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookingVideoRental.Tests
{
    [TestClass()]
    public class mainFormTests
    {
        [TestMethod()]
        public void mainFormTest()
        {
            mainForm mainForm = new mainForm();
            //mainForm.SelectQuery("select * from Customer");
            Assert.IsTrue(true);
        }
    }
}