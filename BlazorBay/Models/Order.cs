using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorBay.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PaymentMethod { get; set; } // e.g., "Cash" or "Online"

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }

        // Optional: Store product names as comma-separated values
        public string OrderedProducts { get; set; }
    }
}
