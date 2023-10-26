using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeyDeHount.Persistence.Manage;

namespace LeyDeHount.Domain
{
    class Party
    {
        public String acronym { get; set; }
        public String namep { get; set; }
        public String president { get; set; }
        public PartyManage pm { get; set; }

        public Party()
        {
            pm = new PartyManage();
        }
        public Party(string acronym, string namep, string president)
        {
            this.acronym = acronym;
            this.namep = namep;
            this.president = president;
            pm = new PartyManage();
        }

        public List<Party> getListParties()
        {
            return pm.listParties;
        }

        public void addParty(string acronym, string namep, string president)
        {
            pm.addParty(acronym,namep,president);
        }

        public void deleteParty(Party party)
        {
            pm.listParties.Remove(party);
        }
    }
}
