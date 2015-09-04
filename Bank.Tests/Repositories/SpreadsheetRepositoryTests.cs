using System.Data.Entity;
using Bank.Models;
using Bank.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bank.Tests.Repositories
{
    [TestClass]
    public class SpreadsheetRepositoryTests
    {
        [TestMethod]
        public void Create()
        {
            var spreadsheet = new Spreadsheet();
            var mockSet = new Mock<DbSet<Spreadsheet>>();
            
            var context = new Mock<ApplicationDbContext>();
            context.Setup(m => m.Spreadsheets).Returns(mockSet.Object); 

            var repo = new SpreadsheetRepository(context.Object); 
            repo.Create(spreadsheet);

            mockSet.Verify(set=>set.Add(It.IsAny<Spreadsheet>()));
        }

        [TestMethod]
        public void Find()
        {
            var spreadsheet = new Spreadsheet();
            var mockSet = new Mock<DbSet<Spreadsheet>>();
            mockSet.Setup(set => set.Find(1)).Returns(spreadsheet);

            var context = new Mock<ApplicationDbContext>();
            context.Setup(m => m.Spreadsheets).Returns(mockSet.Object);

            var repo = new SpreadsheetRepository(context.Object);
            var result = repo.Find(1);

            mockSet.Verify(set => set.Find(1));
            Assert.AreEqual(spreadsheet, result);
        }
    }
}