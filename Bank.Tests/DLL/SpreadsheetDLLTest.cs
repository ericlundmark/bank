using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank.DLL;
using Bank.Models;
using System.Linq;

namespace Bank.Tests.DLL
{
    [TestClass]
    public class SpreadsheetDLLTest
    {
        SpreadsheetDLL dll;

        [TestInitialize]
        public void TestInit() {
            dll = new SpreadsheetDLL();
        }

        [TestMethod]
        public void Create()
        {
            Spreadsheet spreadsheet = new Spreadsheet();

            spreadsheet.Name = "wed";
            spreadsheet = dll.Create(spreadsheet);
            bool exist = dll.SpreadsheetExists(spreadsheet.Id);

            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void Update()
        {
            Spreadsheet spreadsheet = new Spreadsheet();

            spreadsheet = dll.Create(spreadsheet);
            spreadsheet.Name = "name";
            dll.Save(spreadsheet);

            Assert.AreEqual("name", spreadsheet.Name);
        }

        [TestMethod]
        public void Remove()
        {
            Spreadsheet spreadsheet = new Spreadsheet();

            spreadsheet = dll.Create(spreadsheet);
            spreadsheet.Name = "name";
            dll.Remove(spreadsheet);

            bool exist = dll.SpreadsheetExists(spreadsheet.Id);

            Assert.IsFalse(exist);
        }

        [TestCleanup]
        public void TearDown()
        {
            dll.Dispose(true);
        }
    }
}
