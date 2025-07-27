namespace GameManagement.Model
{
    public class Game
    {
        public int Id { get; set; }
        public  string Name { get; set; } 
        public string Description { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; } // "active" or "inactive"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
