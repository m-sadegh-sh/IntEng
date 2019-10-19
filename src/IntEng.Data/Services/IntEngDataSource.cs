namespace IntEng.Data.Services {
    using System.Collections.Generic;
    using System.Linq;

    using IntEng.Data.Domain;

    public static class IntEngDataSource {
        private static readonly IntEngDatabase _intEngDatabase;

        static IntEngDataSource() {
            _intEngDatabase = new IntEngDatabase();

            //_intEngDatabase.ExecuteInsert("Categories", new object[] {"spring", "بهاره"});
            //_intEngDatabase.ExecuteInsert("Categories", new object[] {"summer", "تابستانه"});
            //_intEngDatabase.ExecuteInsert("Categories", new object[] {"fall", "پاییزه"});
            //_intEngDatabase.ExecuteInsert("Categories", new object[] {"winter", "زمستانه"});

            //_intEngDatabase.ExecuteInsert("Products",
            //                              new object[] {
            //                                               370000M, "jacket", "ژاکت", "با کیفیت عالی",
            //                                               GetAllCategories().ElementAt(0).Id
            //                                           });

            //_intEngDatabase.ExecuteInsert("Products",
            //                              new object[] {
            //                                               250000M, "tshirt", "تی شرت", "با کیفیت عالی",
            //                                               GetAllCategories().ElementAt(0).Id
            //                                           });

            //_intEngDatabase.ExecuteInsert("Products",
            //                              new object[]
            //                              {12000M, "hat", "کلاه", "با کیفیت عالی", GetAllCategories().ElementAt(0).Id});

            //_intEngDatabase.ExecuteInsert("Products",
            //                              new object[] {
            //                                               830000M, "mantoux", "مانتو", "با کیفیت عالی",
            //                                               GetAllCategories().ElementAt(0).Id
            //                                           });

            //_intEngDatabase.ExecuteInsert("Products",
            //                              new object[]
            //                              {9000M, "Bot", "بوت", "با کیفیت عالی", GetAllCategories().ElementAt(0).Id});
        }

        public static Category AllCategory {
            get { return _intEngDatabase.GetCategories().OrderBy(c => c.Id).FirstOrDefault(); }
        }

        public static IEnumerable<Category> GetAllCategories() {
            return _intEngDatabase.GetCategories();
        }

        public static IEnumerable<Category> GetTopCategories() {
            return _intEngDatabase.GetCategories().Take(10);
        }

        public static IEnumerable<Category> GetNavCategories() {
            return _intEngDatabase.GetCategories().Except(new[] {AllCategory}).Take(10);
        }

        public static Category GetCategory(int id) {
            return _intEngDatabase.GetCategories().FirstOrDefault(c => c.Id == id);
        }

        public static IEnumerable<Product> GetAllProducts() {
            return _intEngDatabase.GetProducts();
        }

        public static IEnumerable<Product> GetFeaturesProducts() {
            return _intEngDatabase.GetProducts().Take(3);
        }

        public static IEnumerable<Product> GetFeaturesProducts(string categorySlug) {
            return _intEngDatabase.GetProducts().Where(p => p.Category.Slug == categorySlug).Take(3);
        }

        public static IEnumerable<Product> GetTopProducts() {
            return _intEngDatabase.GetProducts().Take(14);
        }

        public static IEnumerable<Product> GetTopProducts(int categoryId) {
            return _intEngDatabase.GetProducts().Where(p => p.Category.Id == categoryId).Take(14);
        }

        public static ICollection<Product> Search(string q,
                                                  int? categoryId,
                                                  decimal? unitPriceLowerBound,
                                                  decimal? unitPriceUpperBound) {
            var products = _intEngDatabase.GetProducts().AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
                products = products.Where(p => p.Name.Contains(q));

            if (categoryId.HasValue && categoryId != 0)
                products = products.Where(p => p.Category.Id == categoryId);

            if (unitPriceLowerBound.HasValue)
                products = products.Where(p => p.UnitPrice >= unitPriceLowerBound);

            if (unitPriceUpperBound.HasValue)
                products = products.Where(p => p.UnitPrice <= unitPriceUpperBound);

            return products.ToList().AsReadOnly();
        }

        public static Product GetProduct(int id) {
            return _intEngDatabase.GetProducts().FirstOrDefault(p => p.Id == id);
        }
    }
}