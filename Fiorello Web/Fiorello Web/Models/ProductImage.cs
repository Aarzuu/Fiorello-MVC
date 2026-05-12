namespace Fiorello_Web.Models
{
    public class ProductImage :BaseEntity
    {
        public string Image { get; set; }
        public bool IsMain { get; set; } = false;
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
