using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeyDeHount.Domain;

namespace LeyDeHount.Persistence.Manage
{
    internal class PartyManage
    {
        public DataTable table { get; set; }
        public List<Party> listParties { get; set; }


        public PartyManage()
        {
            table = new DataTable();
            listParties = new List<Party>();
        }

        public void addParty(string acronym, string namep, string president)
        {
            listParties.Add(new Party(acronym, namep,president));
        }

        
    }
}
