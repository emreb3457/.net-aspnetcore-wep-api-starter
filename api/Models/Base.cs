namespace api.Models
{
    public class Base
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Base()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}