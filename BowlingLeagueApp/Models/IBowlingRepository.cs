using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueApp.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        public void AddBowler(Bowler bowler);
        public void RemoveBowler(Bowler bowler);
        public void UpdateBowler(Bowler bowler);
    }
}
