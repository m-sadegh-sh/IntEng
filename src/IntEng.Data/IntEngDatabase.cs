namespace IntEng.Data {
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;

    using IntEng.Data.Domain;

    public sealed class IntEngDatabase : DbOperationBase {
        public IntEngDatabase()
            : base(ConfigurationManager.AppSettings["ServerName"], ConfigurationManager.AppSettings["DatabaseName"]) {}

        public IList<Category> GetCategories(Func<Category, bool> predicate = null) {
            const string categoriesSelectQuery = "select * from categories";

            var categories = new List<Category>();

            var sqlDataReader = InternalGetSqlDataReader(categoriesSelectQuery);

            if (sqlDataReader == null)
                return categories;

            while (sqlDataReader.Read())
                categories.Add(ParseCategory(sqlDataReader));

            sqlDataReader.Close();

            if (predicate != null)
                categories = categories.Where(predicate).ToList();

            return categories;
        }

        private static Category ParseCategory(IDataRecord sqlDataReader) {
            var category = new Category {
                Id = int.Parse(sqlDataReader["Id"].ToString()),
                Slug = sqlDataReader["Slug"].ToString(),
                Name = sqlDataReader["Name"].ToString()
            };

            return category;
        }

        public IList<Product> GetProducts(Func<Product, bool> predicate = null) {
            const string productsSelectQuery = "select * from products";

            var products = new List<Product>();

            var sqlDataReader = InternalGetSqlDataReader(productsSelectQuery);

            if (sqlDataReader == null)
                return products;

            while (sqlDataReader.Read())
                products.Add(ParseProduct(sqlDataReader));

            sqlDataReader.Close();

            if (predicate != null)
                products = products.Where(predicate).ToList();

            return products;
        }

        private static Product ParseProduct(IDataRecord sqlDataReader) {
            var product = new Product {
                Id = int.Parse(sqlDataReader["Id"].ToString()),
                UnitPrice = decimal.Parse(sqlDataReader["UnitPrice"].ToString()),
                Slug = sqlDataReader["Slug"].ToString(),
                Name = sqlDataReader["Name"].ToString(),
                Description = sqlDataReader["Description"].ToString(),
                CategoryId = int.Parse(sqlDataReader["CategoryId"].ToString())
            };

            return product;
        }
    }
}