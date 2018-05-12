using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comus.Domain.Models
{
    public class Conveyor
    {
        public int ConveyorId { get; set; }
        public int Number { get; set; }
        public int Title { get; set; }
        public int PossibleVolume { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DateOfLastStart { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
