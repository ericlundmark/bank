using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Bank.BLL;
using Bank.DLL;
using Bank.Models;
using Bank.Repositories;

namespace Bank.Controllers
{
    public class SpreadsheetsController : ApiController
    {
        private readonly ISpreadsheetBLL _bll;

        public SpreadsheetsController()
        {
            _bll = new SpreadsheetBLL(new SpreadsheetRepository());
        }

        public SpreadsheetsController(ApplicationDbContext context)
        {
            _bll = new SpreadsheetBLL(new SpreadsheetRepository(context));
        }

        // GET: api/Spreadsheets
        [ResponseType(typeof(List<Spreadsheet>))]
        public IHttpActionResult GetSpreadsheets()
        {
            return Ok(_bll.List());
        }

        // GET: api/Spreadsheets/5
        [ResponseType(typeof(Spreadsheet))]
        public IHttpActionResult GetSpreadsheet(int id)
        {
            Spreadsheet spreadsheet = _bll.Find(id);
            if (spreadsheet == null)
            {
                return NotFound();
            }

            return Ok(spreadsheet);
        }

        // PUT: api/Spreadsheets/5
        [ResponseType(typeof(void))]
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
                _bll.Save(spreadsheet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_bll.SpreadsheetExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Spreadsheets
        [ResponseType(typeof(Spreadsheet))]
        public IHttpActionResult PostSpreadsheet(Spreadsheet spreadsheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bll.Create(spreadsheet);

            return CreatedAtRoute("DefaultApi", new { id = spreadsheet.Id }, spreadsheet);
        }

        // DELETE: api/Spreadsheets/5
        [ResponseType(typeof(Spreadsheet))]
        public IHttpActionResult DeleteSpreadsheet(int id)
        {
            Spreadsheet spreadsheet = _bll.Find(id);
            if (spreadsheet == null)
            {
                return NotFound();
            }

            _bll.Remove(spreadsheet);

            return Ok(spreadsheet);
        }

        protected override void Dispose(bool disposing)
        {
            
            _bll.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}