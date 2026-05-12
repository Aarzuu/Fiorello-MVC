namespace Fiorello_Web.Models
{
    public class Blog :BaseEntity
    {
        public DateOnly CreatedDate { get; set; }
        public string Caption { get; set; }
        public string Context { get; set; }
        public IEnumerable<BlogImage> BlogImages { get; set; }
    }
}
