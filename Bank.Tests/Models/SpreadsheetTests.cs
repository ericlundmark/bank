using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bank.Models;
using Bank.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Tests.Models
{
    [TestClass]
    public class SpreadsheetTests
    {
        [TestMethod]
        public void Validate_WithRequiredValues_Validates()
        {
            var spreadsheet = new SpreadsheetDataBuilder().WithRequiredValues().Build();
            var context = new ValidationContext(spreadsheet, null, null);
            var results = new List<ValidationResult>();

            var actual = Validator.TryValidateObject(spreadsheet, context, results);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Validate_Name_CannotBeNull()
        {
            var spreadsheet = new SpreadsheetDataBuilder().WithRequiredValues().WithName(null).Build();
            var context = new ValidationContext(spreadsheet, null, null);
            var results = new List<ValidationResult>();

            var actual = Validator.TryValidateObject(spreadsheet, context, results);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Validate_Name_CannotBeEmpty()
        {
            var spreadsheet = new SpreadsheetDataBuilder().WithRequiredValues().WithName("").Build();
            var context = new ValidationContext(spreadsheet, null, null);
            var results = new List<ValidationResult>();

            var actual = Validator.TryValidateObject(spreadsheet, context, results);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Validate_Creator_CannotBeNull()
        {
            var spreadsheet = new SpreadsheetDataBuilder().WithRequiredValues().WithCreator(null).Build();
            var context = new ValidationContext(spreadsheet, null, null);
            var results = new List<ValidationResult>();

            var actual = Validator.TryValidateObject(spreadsheet, context, results);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Validate_Investment_CannotBeNull()
        {
            var spreadsheet = new SpreadsheetDataBuilder().WithRequiredValues().WithInvestement(null).Build();
            var context = new ValidationContext(spreadsheet, null, null);
            var results = new List<ValidationResult>();

            var actual = Validator.TryValidateObject(spreadsheet, context, results);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Validate_ROI_ShouldHaveDefaultValue()
        {
            var spreadsheet = new SpreadsheetDataBuilder().WithRequiredValues().Build();
            var context = new ValidationContext(spreadsheet, null, null);
            var results = new List<ValidationResult>();

            var actual = Validator.TryValidateObject(spreadsheet, context, results);
            Assert.IsFalse(actual);
        }
    }
}