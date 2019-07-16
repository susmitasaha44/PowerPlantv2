using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPlantV2.Models
{
    public class PowerplantSite
    {
        public int Id { get; set; }
        public string Sitename { get; set; }
        public string Contactname { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Capacity { get; set; }
        public string UsefulLife { get; set; }
        public string ProjectCost { get; set; }
        public string Loan { get; set; }

        public string ConsumerID { get; set; }

        public Consumer Consumer { get; set; }


    }
}
