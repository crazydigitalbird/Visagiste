namespace Visagiste.Models
{
    public class PhotoTagJunction
    {
        public int Id { get; set; }

        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
