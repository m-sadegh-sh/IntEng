namespace IntEng.Web.Mvc {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapRoute("Contact", "contact", new {controller = "Home", action = "Contact"});

            routes.MapRoute("Categories", string.Empty, new {controller = "Categories", action = "All"});

            routes.MapRoute("Products",
                            "{categoryId}-{categorySlug}",
                            new {controller = "Categories", action = "Products"});

            routes.MapRoute("Details",
                            "{categoryId}-{categorySlug}/{productId}-{productSlug}",
                            new {controller = "Categories", action = "Details"});

            routes.MapRoute("OrderStart", "order/start", new {controller = "Order", action = "Start"});

            routes.MapRoute("OrderSecond", "order/second", new {controller = "Order", action = "Second"});

            routes.MapRoute("OrderFinish", "order/finish", new {controller = "Order", action = "Finish"});

            routes.MapRoute("Cart", "cart", new {controller = "Cart", action = "Details"});

            routes.MapRoute("CartAdd", "cart/add/{productId}-{productSlug}", new {controller = "Cart", action = "Add"});

            routes.MapRoute("Search", "search", new {controller = "Search", action = "Results"});

            routes.MapRoute("Login", "admin/login", new {controller = "Admin", action = "Login"});

            routes.MapRoute("Logout", "admin/logout", new {controller = "Admin", action = "Logout"});

            routes.MapRoute("List", "admin", new {controller = "Admin", action = "List"});

            routes.MapRoute("New", "admin/new", new {controller = "Admin", action = "New"});

            routes.MapRoute("Edit",
                            "admin/edit/{productId}-{productSlug}",
                            new {controller = "Admin", action = "Edit"});

            routes.MapRoute("Remove",
                            "admin/remove/{productId}-{productSlug}",
                            new {controller = "Admin", action = "Remove"});
        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}