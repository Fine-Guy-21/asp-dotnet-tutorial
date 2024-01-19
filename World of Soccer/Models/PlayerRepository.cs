using Microsoft.AspNetCore.DataProtection.Repositories;

namespace World_of_Soccer.Models
{
    public class PlayerRepository 
    {
        public List<Player> PlayerList()
        {
            return new List<Player>()
            {
                new Player() {Id=1,Name="Erling Haaland",Age=23,KitNumber=9,PTeam=1, DominantFoot="Right"},
                new Player() {Id=2,Name="Julian Alvarez",Age=21,KitNumber=19,PTeam=1, DominantFoot="Right"},
                new Player() {Id=3,Name="Dominic Szobozlai",Age=24,KitNumber=28,PTeam=2, DominantFoot="Left"},
                new Player() {Id=4,Name="Martin Odegard",Age=28,KitNumber=8,PTeam=3, DominantFoot="Left"},
                new Player() {Id=5,Name="kevin De bruyne",Age=31,KitNumber=17,PTeam=1, DominantFoot="Right"},
                new Player() {Id=6,Name="Mohamed Salah",Age=32,KitNumber=11,PTeam=2, DominantFoot="Right"},

            };            
        }

        public List<Player> GetAllPlayers() 
        {
            return PlayerList();
        }
    }
}
