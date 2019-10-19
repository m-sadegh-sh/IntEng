namespace IntEng.Web.Mvc.Controllers {
    using System.Web.Mvc;

    using IntEng.Data.Services;
    using IntEng.Web.Mvc.Models;

    public class SearchController : Controller {
        public ActionResult Advanced(SearchInputModel searchModel) {
            return View();
        }

        public ActionResult Results(string q, string cid, string uplb, string upub) {
            var searchInput = SearchInputModel.TryCreate(q, cid, uplb, upub);

            var products = IntEngDataSource.Search(searchInput.Query, searchInput.CategoryId,
                                                 searchInput.UnitPriceLowerBound, searchInput.UnitPriceUpperBound);

            return View(new SearchResultModel {Input = searchInput, Results = products});
        }
    }
}