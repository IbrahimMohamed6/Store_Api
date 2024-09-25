
using Store.Data.Entities.Brands;
using Store.Data.Entities.Type;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Data.Entities
{
    public class Product:BaseEntity<int>
    {
        [Required(ErrorMessage ="Name Is Requierd Ya Hamada")]
        public string Name { get; set; }=null!;
        public string? Description { get; set; }
        [Required(ErrorMessage = "Price Is Requierd Ya Hamada")]

        public decimal Price { get; set; }
        public string PictureUrl { get; set; }= null!;
        public ProductType Type { get; set; }= null!;

        public int TypeId { get; set; }

        public ProductBrands Brand { get; set; } = null!;

        public int BrandId { get; set; }



    }
}
