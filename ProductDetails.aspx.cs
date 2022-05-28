using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //throw new InvalidOperationException("An InvalidOperationException " +
            //    "occurred in the Page_Load handler on the Default.aspx page.");
        }

        public IQueryable<Product> GetProduct(
            [QueryString("ProductID")] int? productId,
            [RouteData] string productName)
        {
            var _db = new ProductContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p =>
                      string.Compare(p.ProductName, productName) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}