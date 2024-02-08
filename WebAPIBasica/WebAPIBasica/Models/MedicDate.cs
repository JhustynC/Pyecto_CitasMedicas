namespace WebAPIBasica.Models
{
    public class MedicDate
    {
        public int Id { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public TimeSpan Hour { get; set; }
        public string Date { get; set; }
    }
}
