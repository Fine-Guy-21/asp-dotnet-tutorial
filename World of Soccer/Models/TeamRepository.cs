using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace World_of_Soccer.Models
{
    public class TeamRepository 
    {
        //public List<Team> Teams = new List<Team> ();

        private readonly SoccerContext SoccerCon;
        public TeamRepository(SoccerContext SoccerCon)
        {
            this.SoccerCon = SoccerCon;
        }

        public object Teams { get; private set; }

        public Team AddTeam(Team team)
        {   
            SoccerCon.Teams.Add(team);
            SoccerCon.SaveChanges();
            return team;
        }
        public List<Team> GetAllTeams()
        {
            return this.SoccerCon.Teams.ToList();
        }
        public Team GetTeamById(int id) 
        {
            Team? team = this.SoccerCon.Teams
                .Include(t => t.TeamKits)
                .Where(t=>t.TeamId==id)
                .FirstOrDefault();

            return team;
        }

        
        public Team UpdateTeam(Team team)
        {
            SoccerCon.Teams.Update(team);
            SoccerCon.SaveChanges();
            return team;
        }

        public void DeleteTeam(Team team)
        {

            SoccerCon.Teams.Remove(team);
            SoccerCon.SaveChanges();
            
        }
    }
}
