using ODataService.Models;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace ODataService.Controllers
{
    public class ProductsController : ODataController
    {
        private ProductsRepository db = new ProductsRepository(HttpContext.Current.Session, "Products");

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.Products.AsQueryable();
        }

        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            
            return Created(product);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<Product> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = db.Products.FirstOrDefault(p => p.ID == key);

            if (entity == null)
            {
                return NotFound();
            }

            product.Patch(entity);

            return Updated(entity);
        }

        public IHttpActionResult Put([FromODataUri] int key, Delta<Product> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = db.Products.FirstOrDefault(p => p.ID == key);

            if (entity == null)
            {
                return NotFound();
            }

            product.Put(entity);

            return Updated(entity);
        }

        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var entity = db.Products.FirstOrDefault(p => p.ID == key);

            if (entity == null)
            {
                return NotFound();
            }

            db.Products.Remove(entity);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}