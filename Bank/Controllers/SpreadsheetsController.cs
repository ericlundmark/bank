using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Bank.Models;
using Bank.BLL;
using Bank.DLL;

namespace Bank.Controllers
{
    public class SpreadsheetsController : ApiController
    {
        ISpreadsheetBLL bll = new SpreadsheetBLL(new SpreadsheetDLL());

        // GET: api/Spreadsheets
        public IQueryable<Spreadsheet> GetSpreadsheets()
        {
            return bll.List();
        }

        // GET: api/Spreadsheets/5
        [ResponseType(typeof(Spreadsheet))]
        public IHttpActionResult GetSpreadsheet(int id)
        {
            Spreadsheet spreadsheet = bll.Find(id);
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
                bll.Save(spreadsheet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bll.SpreadsheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            bll.Create(spreadsheet);

            return CreatedAtRoute("DefaultApi", new { id = spreadsheet.Id }, spreadsheet);
        }

        // DELETE: api/Spreadsheets/5
        [ResponseType(typeof(Spreadsheet))]
        public IHttpActionResult DeleteSpreadsheet(int id)
        {
            Spreadsheet spreadsheet = bll.Find(id);
            if (spreadsheet == null)
            {
                return NotFound();
            }

            bll.Remove(spreadsheet);

            return Ok(spreadsheet);
        }

        protected override void Dispose(bool disposing)
        {
            
            bll.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}