using System.ComponentModel.DataAnnotations;

namespace Store.Services.Services.BasketService.Dtos
{
    public class BasketItemDto
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage ="Price Must Be Grater Than Zero Ya Hamada")]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Quentity Must Be Between One And 10 Pecic Ya Hamada")]


        public string PictureUrl { get; set; }
        [Required]
        public string PrandName { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}