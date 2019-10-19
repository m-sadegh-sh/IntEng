namespace IntEng.Web.Mvc.Models {
    public class SearchInputModel {
        public string Query { get; set; }

        public bool HasQuery {
            get { return !string.IsNullOrWhiteSpace(Query); }
        }

        public int? CategoryId { get; set; }

        public decimal? UnitPriceLowerBound { get; set; }
        public decimal? UnitPriceUpperBound { get; set; }

        public static SearchInputModel TryCreate(string q, string categoryIdString,
                                            string unitPriceLowerBoundString, string unitPriceUpperBoundString) {
            var searchInput = new SearchInputModel {Query = (q ?? string.Empty).Trim()};

            int categoryId;
            if (int.TryParse(categoryIdString, out categoryId))
                searchInput.CategoryId = categoryId;

            decimal unitPriceLowerBound;
            if (decimal.TryParse(unitPriceLowerBoundString, out unitPriceLowerBound))
                searchInput.UnitPriceLowerBound = unitPriceLowerBound;

            decimal unitPriceUpperBound;
            if (decimal.TryParse(unitPriceUpperBoundString, out unitPriceUpperBound))
                searchInput.UnitPriceUpperBound = unitPriceUpperBound;

            return searchInput;
        }
    }
}