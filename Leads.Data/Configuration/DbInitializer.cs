using Leads.Data.Contexts;
using Leads.Domain.Aggregates.Lead;
using Leads.Domain.Entities;

namespace Leads.Data.Configuration
{
    public static class DbInitializer
    {
        public static void Initialize(LeadsDbContext context)
        {
            if (context.Leads.Any())
            {
                return; 
            }

            var suburb = new Suburb() { Id = Guid.NewGuid(), Name = "Brighton", Number = 1080 };
            var suburb1 = new Suburb() { Id = Guid.NewGuid(), Name = "Surry Hills", Number = 777 };
            var suburb2 = new Suburb() { Id = Guid.NewGuid(), Name = "Rockingham", Number = 487 };

            var category = new Category() { Id = Guid.NewGuid(), Name = "Painting" };
            var category1 = new Category() { Id = Guid.NewGuid(), Name = "House Construction" };
            var category2 = new Category() { Id = Guid.NewGuid(), Name = "Masonry" };

            var contact = new Contact() { Id = Guid.NewGuid(), Name = "Gustavo Mello", Email = "gustavo.mello@gmail.com", PhoneNumber = "555-777-999" };
            var contact1 = new Contact() { Id = Guid.NewGuid(), Name = "Silvio Santos", Email = "silvio.Santos@gmail.com", PhoneNumber = "333-222-111" };
            var contact2 = new Contact() { Id = Guid.NewGuid(), Name = "Barack Obama", Email = "gustavo.mello@gmail.com", PhoneNumber = "555-777-999" };


            var leads = new List<Lead>
            {
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Paint a wall", 200m, 0, DateTime.Now, suburb, contact, category1),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Paint some walls", 700m, 0, DateTime.Now, suburb2, contact2, category),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Bricklaying involves laying bricks in mortar to construct and repair walls, partitions, arches, and other structures.", 300m, 0, DateTime.Now, suburb1, contact, category2),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Retaining wall construction involves building walls that hold back soil or rock from a building, structure, or area.", 600m, 0, DateTime.Now, suburb, contact, category1),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Stonework", 900m, 0, DateTime.Now, suburb2, contact, category),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Waterproofing is the application of materials to surfaces to prevent water infiltration, essential for basements, foundations, and roofs.", 400m, 0, DateTime.Now, suburb1, contact2, category2),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Drywall installation", 800m, 0, DateTime.Now, suburb1, contact1, category1),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Accepted, "Stonework involves the construction and repair of structures made from natural stone, such as walls, fireplaces, and decorative features.", 100m, 100m, DateTime.Now, suburb2, contact, category),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Foundation work entails the excavation and construction of the base structure that supports buildings and other structures.", 400m, 0, DateTime.Now, suburb1, contact1, category2),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Stucco application is the process of applying a durable and weather-resistant plaster to exterior surfaces of buildings.", 1000m, 0, DateTime.Now, suburb, contact, category1),
                new Lead(Guid.NewGuid(), Domain.Enums.LeadStatus.Invited, "Paint a wall", 1000m, 0, DateTime.Now, suburb2, contact, category1)
            };

            context.Leads.AddRange(leads);
            context.SaveChanges();
        }
    }
}
