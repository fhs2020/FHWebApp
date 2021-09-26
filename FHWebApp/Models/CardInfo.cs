using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FHWebApp.Models
{
    public class CardInfo
    {
        [Key]
        public Guid CardId { get; set; }

        public int CustomerId { get; set; }

        [MaxLength(16)]
        public long CardNumber { get; set; }

        [MaxLength(5)]
        public int CVV { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid Token { get; set; }
    }
}
