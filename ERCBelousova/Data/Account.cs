using System;
using System.ComponentModel.DataAnnotations;

namespace ERCBelousova.Data
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string? Number { get; set; }
        public string StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Address { get; set; }
        public double Area { get; set; }
        public string Residents { get; set; }
    }
}
