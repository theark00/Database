
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ConsoleAppDatabase.Entities;
using System.ComponentModel.DataAnnotations;
using System;


namespace ConsoleAppDatabase;

public class Program
{
    
    static void Main()
    {
        using (var context = new ContactDbContext())
        {
            context.Database.EnsureCreated();


            while (true)
            {
                Console.Title = "Adressbok";
                Console.WriteLine();
                Console.WriteLine("Contact Book");
                Console.WriteLine();
                Console.WriteLine("Menu");
                Console.WriteLine();
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Remove Contact");
                Console.WriteLine("3. Update Contacts");
                Console.WriteLine("4. View all Contacts");
                Console.WriteLine("5. Search for Contact");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        AddContact(context);
                        break;
                    case "2":
                        RemoveContact(context);
                        break;
                    case "3":
                        UpdateContacts(context);
                        break;
                    case "4":
                        ViewAllContacts(context);
                        break;
                    case "5":
                        Search(context);
                        break;
                    case "6":
                    
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Oops something went wrong. Try again.");
                        Console.ReadKey();
                        break;
                 
                }

            
            }
        }
    }

   static void AddContact(ContactDbContext context)
   {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine()!;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter Address Information: ");
            string addressInformation = Console.ReadLine()!;

            ContactsRoles newContact = new ContactsRoles(firstName, lastName, phoneNumber, email, addressInformation);
            context.ContactRole.Add(newContact);
            try
            {
                context.SaveChanges();
                Console.WriteLine("Contact Added!");
            }
            catch (DbUpdateException ex) 
            { 
                Console.WriteLine($"Could not add contact: {ex.Message}");
            }
            
            Console.Clear();
   }
    static void RemoveContact(ContactDbContext context)
    {
        Console.Write("Enter Email of contact to delete contact: ");
        string deleteEmail = Console.ReadLine()!;

        ContactsRoles foundContact = context.ContactRole.FirstOrDefault(c => c.Email.ToLower() == deleteEmail.ToLower())!;
        if (foundContact != null)
        {
            context.ContactRole.Remove(foundContact);
            Console.WriteLine("Contact has been deleted.");
        }
        else
        {
            Console.WriteLine("Could not find Contact. ");
        }
        context.SaveChanges();
    }
    static void UpdateContacts(ContactDbContext context)
    {
        Console.Write("Enter Name to update contact: ");
        string updateName = Console.ReadLine()!;

        ContactsRoles foundContact = context.ContactRole.FirstOrDefault(c => c.FirstName.ToUpper() == updateName.ToUpper())!;
        if (foundContact != null)
        {
            Console.WriteLine("Enter new contact information");
            Console.Write("Enter New First Name: ");
            foundContact.FirstName = Console.ReadLine()!;

            Console.WriteLine("Enter new Last Name: ");
            foundContact.LastName = Console.ReadLine()!;

            Console.WriteLine("Enter new Phone Number: ");
            foundContact.PhoneNumber = Console.ReadLine()!;

            Console.WriteLine("Enter new Email: ");
            foundContact.Email = Console.ReadLine()!;

            Console.WriteLine("Enter new Address Information: ");
            foundContact.AddressInformation = Console.ReadLine()!; ;
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
        context.SaveChanges();
    }
    static void ViewAllContacts(ContactDbContext context)
    {
        Console.WriteLine();
        Console.WriteLine("All Contacts:");
        Console.WriteLine();
        var contactsRoles = context.ContactRole.ToList();
        if (contactsRoles.Count == 0)
        {
            Console.WriteLine("No Contacts.");
        }
        else
        {
            foreach (var ContactRole in contactsRoles)
            {
                Console.WriteLine(ContactRole);
            }
        }

    }
    static void Search(ContactDbContext context)
    {
        Console.WriteLine("Enter Name: ");
        string search = Console.ReadLine()!;

        ContactsRoles foundContact = context.ContactRole.FirstOrDefault(c => c.FirstName.ToUpper() == search.ToUpper())!;
        if (foundContact == null) 
        {
            
            Console.WriteLine(foundContact);
        }
        else
        {
            Console.WriteLine("Could not find contact by that name. Try again!");
        }
        
    }
    
    public class ContactsRoles
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressInformation { get; set; }

        public ContactsRoles(string firstName, string lastName, string phoneNumber, string email, string addressInformation)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            AddressInformation = addressInformation;

        }
        public override string ToString()
        {
            return $"{FirstName}, LastName: {LastName}, Phone: {PhoneNumber}, Email: {Email}, AddressInformation: {AddressInformation}";
        }
    }
    public class ContactDbContext : DbContext
    {
        
        public DbSet<ContactsRoles> ContactRole { get; set; } 
        
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserInfoContact> UserInfoContacts { get; set; }
        public DbSet<UserInfoAddress> UserInfoAddresses { get; set; }
        public DbSet<User> users { get; set; } 
       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConsoleAppDatabase.Entities.ContactsRoles>().HasKey(c => c.Id);
            modelBuilder.Entity<ConsoleAppDatabase.Entities.UserInfo>().HasKey(c => c.Id);
            modelBuilder.Entity<ConsoleAppDatabase.Entities.UserInfoContact>().HasKey(c => c.Id);
            modelBuilder.Entity<ConsoleAppDatabase.Entities.UserInfoAddress>().HasKey(c => c.Id);
            modelBuilder.Entity<ConsoleAppDatabase.Entities.User>().HasKey(c => c.Id);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:/skolaa/Databas_C/ConsoleAppDatabase/ConsoleAppDatabase/Data/mydatabase.db");
        }
    }
    
}
