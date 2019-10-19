namespace IntEng.Web.Mvc.Controllers {
    using System.Web.Mvc;

    public class CartController : Controller {
        public ActionResult Details() {
            return View();
        }

        public ActionResult Add(int productId, string returnUrl) {
            //Add to Cart

            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);
            return RedirectToRoute("Home");
        }
    }
}