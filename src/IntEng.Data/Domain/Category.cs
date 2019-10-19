namespace IntEng.Data.Domain {
    using System.Collections.Generic;

    public class Category {
        public int Id { get; set; }

        public string Slug { get; set; }
        public string Name { get; set; }

        public IEnumerable<Product> Products {
            get { return new IntEngDatabase().GetProducts(p => p.CategoryId == Id); }
        }
    }
}