namespace IntEng.Web.Mvc.Helpers {
    using System.Globalization;

    public static class LocalizationManager {
        private static readonly CultureInfo _defaultCulture;

        static LocalizationManager() {
            _defaultCulture = CultureInfo.CreateSpecificCulture("fa-IR");
        }

        public static string GetLocalizedPrice(decimal valueToFormat) {
            return string.Format(_defaultCulture, "{0} {1}", valueToFormat, _defaultCulture.NumberFormat.CurrencySymbol);
        }
    }
}