namespace IntEng.Web.Mvc.Helpers {
    using System.Web.Mvc;

    using IntEng.Data.Domain;

    public static class UrlHelperExtensions {
        public static string CategoryUrl(this UrlHelper urlHelper, Category categoryToFormat) {
            return urlHelper.RouteUrl("Products", new {
                                                          categoryId = categoryToFormat.Id,
                                                          categorySlug = categoryToFormat.Slug
                                                      });
        }

        public static string ProductUrl(this UrlHelper urlHelper, Product productToFormat) {
            return urlHelper.RouteUrl("Details", new {
                                                         categoryId = productToFormat.Category.Id,
                                                         categorySlug = productToFormat.Category.Slug,
                                                         productId = productToFormat.Id,
                                                         productSlug = productToFormat.Slug
                                                     });
        }

        public static string ProductTinyImage(this UrlHelper urlHelper, Product productToFormat) {
            return string.Format("/images/products/{0}-small.jpg", productToFormat.Id);
        }

        public static string ProductLargeImage(this UrlHelper urlHelper, Product productToFormat) {
            return string.Format("/images/products/{0}-big.jpg", productToFormat.Id);
        }

        public static string ProductSliderImage(this UrlHelper urlHelper, Product productToFormat) {
            return string.Format("/images/products/{0}-slide.jpg", productToFormat.Id);
        }
    }
}