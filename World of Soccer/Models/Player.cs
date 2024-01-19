namespace World_of_Soccer.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int KitNumber { get; set; }
        public int PTeam { get; set; }
        public String? DominantFoot { get; set;}

        List<IFormFile> PlayerFace = new List<IFormFile>(); 

    }
}
