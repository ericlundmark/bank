using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Bank.Models;
using Bank.Repositories;

namespace Bank.Controllers
{
    [RoutePrefix("api/v1/providers")]
    public class ProvidersController : ApiController
    {
        private readonly IProviderRepository _repository;

        public ProvidersController()
        {
            _repository = new ProviderRepository(new ApplicationDbContext());
        }

        [Route("")]
        public IQueryable<Provider> GetProviders()
        {
            return _repository.List();
        }

        [Route("{id:int}")]
        [ResponseType(typeof(Provider))]
        public IHttpActionResult GetProvider(int id)
        {
            var provider = _repository.Find(id);
            if (provider == null)
            {
                return NotFound();
            }

            return Ok(provider);
        }

        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProvider(int id, Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provider.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Save(provider);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose(disposing);
            base.Dispose(disposing);
        }

        private bool ProviderExists(int id)
        {
            return _repository.ProviderExists(id);
        }
    }
}