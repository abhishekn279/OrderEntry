using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections;
namespace OrderEntry
{
    internal class Program
    {

        internal class createAccount
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public string Address { get; set; }
            public string Company { get; set; }
            public int Contact { get; set; }
            public string State { get; set; }

            string connectionString = "Data Source=LAPTOP-IIUB2OVA\\SQLEXPRESS;Initial Catalog=OrderEntry;Integrated Security=True";
            public void signUp()
            {

                Console.WriteLine("Sign UP");
                Console.WriteLine("Enter Your Name: ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                Password = Console.ReadLine();
                Console.WriteLine("Enter Company Name: ");
                Company = Console.ReadLine();
                Console.WriteLine("Enter Addreess: ");
                Address = Console.ReadLine();
                Console.WriteLine("Enter State: ");
                State = Console.ReadLine();
                Console.WriteLine("Enter Phone Number: ");
                Contact = Convert.ToInt32(Console.ReadLine());
            }

            public void insertIntoDB()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string insQuery = "Insert into UserAccount(Name,Password,Address,State,Company,Contact) values (@Name,@Password,@Address,@State,@Company,@Contact)";
                        using (SqlCommand command = new SqlCommand(insQuery, conn))
                        {
                            command.Parameters.AddWithValue("@Name", Name);
                            command.Parameters.AddWithValue("@Password", Password);
                            command.Parameters.AddWithValue("@Address", Address);
                            command.Parameters.AddWithValue("@Company", Company);
                            command.Parameters.AddWithValue("@Contact", Contact);
                            command.Parameters.AddWithValue("@State", State);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Account inserted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Error inserting account.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    finally
                    {
                        conn?.Close();
                    }
                }
                
            }

                public void displayAccount()
                {
                    Console.WriteLine($"Name: {Name}");
                    Console.WriteLine($"Company: {Company}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"State: {State}");
                    Console.WriteLine($"Contact: {Contact}");
                }
            }
        
        static void Main(string[] args)
        {
            createAccount account = new createAccount();    
            account.signUp();
            account.insertIntoDB();
            account.displayAccount();
            Console.ReadLine();
        }
    }
}
