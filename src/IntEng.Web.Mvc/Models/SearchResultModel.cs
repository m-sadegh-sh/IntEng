namespace IntEng.Web.Mvc.Models {
    using System.Collections.Generic;
    using System.Linq;

    using IntEng.Data.Domain;

    public class SearchResultModel {
        public bool HasAny {
            get { return Results.Any(); }
        }

        public int Count {
            get { return Results.Count(); }
        }

        public SearchInputModel Input { get; set; }

        public IEnumerable<Product> Results { get; set; }
    }
}