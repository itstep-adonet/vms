using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Hospital
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public virtual List<Doctor> Doctors { get; set; }
        public virtual List<Point> Points { get; set; }
    }
}
