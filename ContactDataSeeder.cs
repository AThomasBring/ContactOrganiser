using ContactOrganiser.Models;
using CsvHelper;
using System.Globalization;

namespace ContactOrganiser
{
    public class ContactDataSeeder
    {
        private readonly ContactsDbContext _dbContext;

        public ContactDataSeeder(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedContactsFromCsv(string filePath)
        {
            var existingContacts = _dbContext.Contacts.Any();
            if (!existingContacts)
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        var contact = new Contact
                        {
                            Name = csv.GetField<string>(0),
                            Email = csv.GetField<string>(1),
                            Phone = csv.GetField<string>(2)
                        };

                        _dbContext.Contacts.Add(contact);
                    }

                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
