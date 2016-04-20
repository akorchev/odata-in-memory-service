using ODataService.Models;
using System.Linq;
using System.Web.OData;

namespace ODataService.Controllers
{
    public class ProductsController : ODataController
    {
        private ProductsRepository db = new ProductsRepository();

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.Products.AsQueryable();
        }
    }
}