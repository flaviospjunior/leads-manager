using System.ComponentModel.DataAnnotations;

namespace Leads.Domain.Entities
{
    public class Suburb
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
