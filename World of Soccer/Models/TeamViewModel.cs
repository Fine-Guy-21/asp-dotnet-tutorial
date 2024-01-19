using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace World_of_Soccer.Models
{
    public class TeamViewModel
    {
        [Required(ErrorMessage = "Id is Mandatory")]
        [Display(Name = "TeamID")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "What Show we call Your Team?")]
        [Display(Name = "Name")]
        public string TeamName { get; set; }

        [Required(ErrorMessage = "What to write on the scoreboard?, Max 4 letters ")]
        [Display(Name = "STN")]
        //[RegularExpression(new=)]
        public string ShortTeamName { get; set; }

        [Required(ErrorMessage = "You gotta tell me Who's gonna be Your Coach ")]
        [Display(Name = "Coach")]
        public string CoachName { get; set; }

        [Display(Name = "TeamLogo")]
        public IFormFile? TeamLogo { get; set; }

        [NotMapped]
        [Display(Name = "Kits")]
        public List <IFormFile> Kits { get; set; }
    }
}
