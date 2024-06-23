using System.ComponentModel.DataAnnotations;

namespace Leads.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
