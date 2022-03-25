using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueApp.Models
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlingDbContext _context { get; set; }
        public EFBowlingRepository(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void AddBowler(Bowler bowler)
        {
            _context.Add(bowler);
            _context.SaveChanges();
        }

        public void RemoveBowler(Bowler bowler)
        {
            _context.Remove(bowler);
            _context.SaveChanges();
        }

        public void UpdateBowler(Bowler bowler)
        {
            _context.Update(bowler);
            _context.SaveChanges();
        }
    }
}
