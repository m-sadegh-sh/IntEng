namespace IntEng.Data.Domain {
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Product {
        public int Id { get; set; }

        [DisplayName("قیمت")]
        [Required(ErrorMessage = "قیمت الزامی است.")]
        public decimal UnitPrice { get; set; }

        [DisplayName("اسلاگ")]
        [Required(ErrorMessage = "اسلاگ الزامی است.")]
        public string Slug { get; set; }

        [DisplayName("نام")]
        [Required(ErrorMessage = "نام الزامی است.")]
        public string Name { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("گروه")]
        [Required(ErrorMessage = "گروه الزامی است.")]
        public int CategoryId { get; set; }

        public Category Category {
            get { return new IntEngDatabase().GetCategories(c => c.Id == CategoryId).FirstOrDefault(); }
        }
    }
}