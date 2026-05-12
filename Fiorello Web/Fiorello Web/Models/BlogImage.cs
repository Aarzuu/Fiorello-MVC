namespace Fiorello_Web.Models
{
    public class BlogImage :BaseEntity
    {
        public string Image { get; set; }
        public bool IsMain { get; set; } = false;
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
