using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comus.Domain.Models
{
    public class ConveyorDefect
    {
        public int ConveyorDefectId { get; set; }

        public int ConveyorId { get; set; }
        public Conveyor Conveyor { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get;  set; }

        public int Downtime { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
