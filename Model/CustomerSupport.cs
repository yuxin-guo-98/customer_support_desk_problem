using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customersupport.Model
{
    public class CustomerSupport
    {
        static List<CustomerDTO> CustomersList;

        public CustomerSupport()
        {
            CustomersList = new List<CustomerDTO>() 
            {
                new CustomerDTO { Name="Jojo", Address="25 orchard", Phone=447505565551,  Email="jojo@gmail.com", Username="Jojo123", Password = "Jojo123_123"}
            };
        }

        public List<CustomerDTO> GetAll()
        {
           // List<Customer> CustomerList = new List<Customer>
            return CustomersList;
        }


        public bool Add(CustomerDTO newCustomer)
        {
            bool IsAdded = false;

            if (!(newCustomer.Password.Length >= 10)
                && !(newCustomer.Password.Any(char.IsUpper))
                && !(newCustomer.Password.Any(char.IsLower))
                && !(newCustomer.Password.Any(char.IsDigit))
                && (newCustomer.Password.All(char.IsLetterOrDigit)))
            {
                throw new ArgumentException("Invalid password. Passwords must be 10 characters minimum, " +
                    "contain 1 Upper, 1 lower, 1 number and 1 non alpha numeric character"); 
            }

            try
            {
                CustomersList.Add(newCustomer);
                IsAdded = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return IsAdded;
        }
        

        public bool Update(CustomerDTO UpdatedCustomer)
        {
            bool IsUpdated = false;

            try
            {
                var Emp = CustomersList.FirstOrDefault(e => e.Name == UpdatedCustomer.Name);
                Emp.Address = UpdatedCustomer.Address;
                Emp.Phone = UpdatedCustomer.Phone;
                Emp.Email = UpdatedCustomer.Email;
                Emp.Username = UpdatedCustomer.Username;
                Emp.Password = UpdatedCustomer.Password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return IsUpdated;
        }

    public bool Delete(string name)
    {
        bool IsDeleted = false;
        try
        {
            for (int i = 0; i < CustomersList.Count; i++)
            {
                if (CustomersList[i].Name == name)
                {
                    CustomersList.RemoveAt(i);
                    IsDeleted = true;
                    break;
                }
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return IsDeleted;
    }



    }

    //search button not implemented.
}