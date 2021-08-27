using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWebAPI.Models
{
    public class Medicine
    {
        [Key]
        public string medicineId { get; set; }
        public string medicineName { get; set; }
        public string brand { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999999999999999999.99)]
        public decimal price { get; set; }
        public int quantity { get; set; }
        public DateTime expiryDate { get; set; }
        public string notes { get; set; }
    }
}
