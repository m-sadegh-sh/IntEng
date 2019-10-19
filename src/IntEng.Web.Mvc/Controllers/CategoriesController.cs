namespace IntEng.Web.Mvc.Controllers {
    using System.Collections.Generic;
    using System.Web.Mvc;

    using IntEng.Data;
    using IntEng.Data.Domain;
    using IntEng.Data.Services;

    public class CategoriesController : Controller {
       public ActionResult All() {
            return View(IntEngDataSource.GetAllProducts());
        }

        public ActionResult Products(int categoryId) {
            var category = IntEngDataSource.GetCategory(categoryId);

            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        public ActionResult Details(int categoryId, int productId) {
            var category = IntEngDataSource.GetCategory(categoryId);

            if (category == null)
                return HttpNotFound();

            var product = IntEngDataSource.GetProduct(productId);

            if (product == null)
                return HttpNotFound();

            if (product.Category.Id != category.Id)
                return HttpNotFound();

            return View(product);
        }
    }
}