using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPlantV2.Models
{
    public class Consumer
    {
        public Consumer()
        {
            this.PowerplantSites = new HashSet<PowerplantSite>();
        }
        public string ConsumerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<PowerplantSite> PowerplantSites { get; set; }

    }
}
