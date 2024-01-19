using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace World_of_Soccer.Models
{
    public class Team
    {

        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? TeamShortName { get; set; }
        public string? TeamCoach { get; set;}
        public string? TeamLogo {  get; set;}

        public List <ImageGallery>? TeamKits { get; set; }

        //List<Player> Players = new List<Player>();
        //private static int TeamId = 1;

    }
}
