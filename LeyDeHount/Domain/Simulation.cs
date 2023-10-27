using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeyDeHount.Domain
{
    class Simulation
    {
        public String nameparty { get; set; }
        public int votes { get; set; }
        public int seats { get; set; }

        public Simulation(String nameparty, int votes, int seats) { 
            this.nameparty = nameparty;
            this.votes = votes;
            this.seats = seats;
        }
    }
}
