using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Bank.Models;
using Bank.Repositories;

namespace Bank.Controllers
{
    public class SpreadsheetsController : ApiController
    {
        private readonly ISpreadsheetRepository _repository;

        public SpreadsheetsController()
        {
            _repository = new SpreadsheetRepository(new ApplicationDbContext());
        }

        // GET: api/Spreadsheets
        [ResponseType(typeof (List<Spreadsheet>))]
        public IHttpActionResult GetSpreadsheets()
        {
            return Ok(_repository.List());
        }

        // GET: api/Spreadsheets/5
        [ResponseType(typeof (Spreadsheet))]
        public IHttpActionResult GetSpreadsheet(int id)
        {
            var spreadsheet = _repository.Find(id);
            if (spreadsheet == null)
            {
                return NotFound();
            }

            return Ok(spreadsheet);
        }

        // PUT: api/Spreadsheets/5
        [ResponseType(typeof (void))]
        public IHttpActionResult PutSpreadsheet(int id, Spreadsheet spreadsheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spreadsheet.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Save(spreadsheet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.SpreadsheetExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Spreadsheets
        [ResponseType(typeof (Spreadsheet))]
        public IHttpActionResult PostSpreadsheet(Spreadsheet spreadsheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(spreadsheet);

            return CreatedAtRoute("DefaultApi", new {id = spreadsheet.Id}, spreadsheet);
        }

        // DELETE: api/Spreadsheets/5
        [ResponseType(typeof (Spreadsheet))]
        public IHttpActionResult DeleteSpreadsheet(int id)
        {
            var spreadsheet = _repository.Find(id);
            if (spreadsheet == null)
            {
                return NotFound();
            }

            _repository.Remove(spreadsheet);

            return Ok(spreadsheet);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}