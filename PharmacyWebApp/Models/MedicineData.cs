using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWebApp.Models
{
    public class MedicineData
    {
        public string medicineId { get; set; }
        [DisplayName("Name")]
        public string medicineName { get; set; }
        [DisplayName("Brand")]
        public string brand { get; set; }
        [DisplayName("Price")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999999999999999999.99)]
        public decimal price { get; set; }
        [DisplayName("Quantity")]
        public int quantity { get; set; }
        [DisplayName("Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime expiryDate { get; set; }
        public string notes { get; set; }
    }
}
