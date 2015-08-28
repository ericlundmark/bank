using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Bank.Controllers;
using Bank.DLL;
using Bank.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Tests.Controllers
{
    [TestClass]
    public class SpreadsheetsControllerTest
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly SpreadsheetDll _dll;
        public SpreadsheetsControllerTest()
        {
            _dll = new SpreadsheetDll(_context);
        }

        [TestMethod]
        public void PostSpreadsheets_WithNameAndCreator_OkRequest()
        {
            var controller = new SpreadsheetsController(_context)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var spreadsheet = new Spreadsheet
            {
                Name = "name",
                Creator = new ApplicationUser {UserName = "erix"},
                Investment = 100
            };

            var result = controller.PostSpreadsheet(spreadsheet);

            Assert.IsInstanceOfType(result, typeof (CreatedAtRouteNegotiatedContentResult<Spreadsheet>));
            var spread = result as CreatedAtRouteNegotiatedContentResult<Spreadsheet>;
            Assert.IsNotNull(spread);
            Assert.IsNotNull(spread.Content);
            Assert.AreEqual(1, spread.Content.Id);

            _dll.Remove(spread.Content);
        }

        [TestMethod]
        public void PostSpreadsheets_WithoutRequiredFields_BadRequest()
        {

            var controller = new SpreadsheetsController(_context)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var spreadsheet = new Spreadsheet();
            controller.Validate(spreadsheet);

            var result = controller.PostSpreadsheet(spreadsheet);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (InvalidModelStateResult));
            var modelState = ((InvalidModelStateResult) result).ModelState;
            Assert.AreEqual(3, modelState.Count);
        }

        [TestMethod]
        public void GetSpreadsheet_ThatDoesNotExist_NotFound()
        {

            var controller = new SpreadsheetsController(_context)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var result = controller.GetSpreadsheet(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetSpreadsheet_WithValidId_OkRequest()
        {
            var spreadsheet = new Spreadsheet
            {
                Name = "name",
                Creator = new ApplicationUser { UserName = "erix" },
                Investment = 100
            };

           spreadsheet = _dll.Create(spreadsheet);

            var controller = new SpreadsheetsController(_context)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var result = controller.GetSpreadsheet(spreadsheet.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Spreadsheet>));

            var sheet = result as OkNegotiatedContentResult<Spreadsheet>;
            Assert.AreEqual("name", sheet.Content.Name);
            Assert.AreEqual("erix", sheet.Content.Creator.UserName);
            Assert.AreEqual(100, sheet.Content.Investment);
            Assert.AreEqual(100, sheet.Content.Balance);
            _dll.Remove(sheet.Content);
        }
    }
}