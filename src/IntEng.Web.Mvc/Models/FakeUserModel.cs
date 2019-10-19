namespace IntEng.Web.Mvc.Models {
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class FakeUserModel {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "نام کاربری الزامی است.")]
        public string UserName { get; set; }

        [DisplayName("گذرواژه")]
        [Required(ErrorMessage = "گذرواژه الزامی است.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}