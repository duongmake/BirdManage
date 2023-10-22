using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class BirdDTO
    {
        public int BirdID { get; set; }
        public string? BirdName { get; set; } 

        public int? UserID {  get; set; }

        public int? Estimation { get; set; }
        public string? Gender { get; set; }
        public string? WeightOfBird { get; set; }
        public string? BirdDecription { get; set; }
        public bool? BirdStatus { get; set; }
    }
}
