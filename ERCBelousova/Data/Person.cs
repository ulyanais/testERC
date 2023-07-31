using System.ComponentModel.DataAnnotations;

namespace ERCBelousova.Data
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FullName { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
