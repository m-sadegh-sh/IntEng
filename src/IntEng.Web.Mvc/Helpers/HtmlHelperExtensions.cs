namespace IntEng.Web.Mvc.Helpers {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using IntEng.Data.Domain;

    public static class HtmlHelperExtensions {
        public static IHtmlString CategoryLink(this HtmlHelper htmlHelper, Category categoryToFormat) {
            return htmlHelper.RouteLink(categoryToFormat.Name, "Products", new {
                                                                                   categoryId = categoryToFormat.Id,
                                                                                   categorySlug = categoryToFormat.Slug
                                                                               });
        }

        public static IHtmlString ProductLink(this HtmlHelper htmlHelper, Product productToFormat) {
            return htmlHelper.RouteLink(productToFormat.Name, "Details", new {
                                                                                 categoryId =
                                                                             productToFormat.Category.Id,
                                                                                 categorySlug =
                                                                             productToFormat.Category.Slug,
                                                                                 productId = productToFormat.Id,
                                                                                 productSlug = productToFormat.Slug
                                                                             });
        }
    }
}