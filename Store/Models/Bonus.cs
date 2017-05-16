using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Enums;

namespace Store.Models
{
    public class Bonus
    {
        [Key]
        [ForeignKey("Game")]
        public Guid Id { get; set; }

        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public BonusType BonusType { get; set; }
        public decimal Value { get; set; }
    }
}
