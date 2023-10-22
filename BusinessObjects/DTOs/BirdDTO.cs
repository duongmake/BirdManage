using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class BirdDTO
    {
        public int BirdId { get; set; }
        public string BirdName { get; set; } = null!;
        public int? Estimation { get; set; }
        public string? Gender { get; set; }
        public string? WeightofBirds { get; set; }
        public string? BirdDescription { get; set; }
        public bool? BirdStatus { get; set; }
    }
}
