namespace IntEng.Web.Mvc.Controllers {
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Security;

    using IntEng.Data;
    using IntEng.Data.Domain;
    using IntEng.Data.Services;
    using IntEng.Web.Mvc.Models;

    public class AdminController : Controller {
        private readonly IntEngDatabase _intEngDatabase;

        public AdminController() {
            _intEngDatabase = new IntEngDatabase();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl ?? Url.RouteUrl("List");
            ViewBag.HasError = false;

            return View(new FakeUserModel());
        }

        [HttpPost]
        public ActionResult Login(FakeUserModel fakeUserModel, string returnUrl) {
            ViewBag.ReturnUrl = returnUrl ?? Url.RouteUrl("List");

            if (fakeUserModel == null)
                return HttpNotFound();

            if (!ModelState.IsValid) {
                ViewBag.HasError = true;
                return View(fakeUserModel);
            }

            if (fakeUserModel.UserName == "sadegh" && fakeUserModel.Password == "iman") {
                FormsAuthentication.RedirectFromLoginPage(fakeUserModel.UserName, true);

                return Redirect(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "نام کاربری و/یا گذرواژه صحیح نمی باشد.");
            ViewBag.HasError = true;
            return View(fakeUserModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Logout(string returnUrl) {
            FormsAuthentication.SignOut();

            return Redirect(returnUrl ?? "~/");
        }

        [Authorize]
        public ActionResult List() {
            ViewBag.HasError = false;

            return View(IntEngDataSource.GetAllProducts());
        }

        [Authorize]
        [HttpGet]
        public ActionResult New(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl ?? Url.RouteUrl("List");
            ViewBag.HasError = false;

            return View(new Product());
        }

        [Authorize]
        [HttpPost]
        public ActionResult New(Product product, string returnUrl) {
            ViewBag.ReturnUrl = returnUrl ?? Url.RouteUrl("List");

            if (product == null)
                return HttpNotFound();

            if (!ModelState.IsValid) {
                ViewBag.HasError = true;
                return View(product);
            }

            if (_intEngDatabase.ExecuteInsert("Products",
                                              new object[] {
                                                  product.UnitPrice, product.Slug, product.Name, product.Description,
                                                  product.CategoryId
                                              }))
                //return View("_Success", ViewBag.ReturnUrl);
                return Redirect(ViewBag.ReturnUrl);

            ModelState.AddModelError(string.Empty, "خطایی رخ داده است.");
            ViewBag.HasError = true;
            return View(product);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int productId, string returnUrl) {
            ViewBag.ReturnUrl = returnUrl ?? Url.RouteUrl("List");
            ViewBag.HasError = false;

            var product = IntEngDataSource.GetProduct(productId);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Product product, string returnUrl) {
            ViewBag.ReturnUrl = returnUrl ?? Url.RouteUrl("List");

            if (product == null)
                return HttpNotFound();

            if (!ModelState.IsValid) {
                ViewBag.HasError = true;
                return View(product);
            }

            var columnNameValues = new Dictionary<string, object> {
                {"UnitPrice", product.UnitPrice},
                {"Slug", product.Slug},
                {"Name", product.Name},
                {"Description", product.Description},
                {"CategoryId", product.CategoryId}
            };

            if (_intEngDatabase.ExecuteUpdate("Products", "Id", product.Id, columnNameValues))
                //return View("_Success", ViewBag.ReturnUrl);
                return Redirect(ViewBag.ReturnUrl);

            ModelState.AddModelError(string.Empty, "خطایی رخ داده است.");
            ViewBag.HasError = true;
            return View(product);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Remove(int productId, string returnUrl) {
            ViewBag.ReturnUrl = returnUrl ?? Url.RouteUrl("List");

            var product = IntEngDataSource.GetProduct(productId);

            if (product == null)
                return HttpNotFound();

            if (_intEngDatabase.ExecuteDelete("Products", "Id", product.Id))
                //return View("_Success", ViewBag.ReturnUrl);
                return Redirect(ViewBag.ReturnUrl);

            ModelState.AddModelError(string.Empty, "خطایی رخ داده است.");
            ViewBag.HasError = true;
            return RedirectToAction("List");
        }
    }
}