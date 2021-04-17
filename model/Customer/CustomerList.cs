using System;

namespace ShopConsole
{
    public class CustomerList
    {
        public CustomerNode headCustomer;

        //Constructors
        public CustomerList()
        {
            headCustomer = null;
        }
        public CustomerList(CustomerNode headCustomer)
        {
            this.headCustomer = headCustomer;
        }

        //Getters and Setters
        public CustomerNode HeadCustomer
        {
            get { return headCustomer; }
            set { headCustomer = value; }
        }

        /*=========================================METHODS================================*/
        // Method to get the size of the list
        public int getSize()
        {
            CustomerNode tmp = null;
            int count = 0;
            if (this.HeadCustomer != null)
            {
                tmp = this.HeadCustomer;
                while (tmp.Next != null)
                {
                    count++;
                    tmp = tmp.Next;
                }
            }
            return count;
        }

        // Method to get the last node in the list
        public CustomerNode getLastNode()
        {
            CustomerNode tmp = null;
            if (this.HeadCustomer != null)
            {
                tmp = this.HeadCustomer;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
            }
            return tmp;
        }

        // Method to add a new customer to the list
        public bool AddCustomer(Customer customerData)
        {
            if (customerData == null)
            {
                return false;
            }
            if (headCustomer == null)
            {
                headCustomer = new CustomerNode();
                headCustomer.Customer = customerData;
            }
            else
            {
                if (searchCustomerById(customerData.IdCustomer) == false)
                {
                    CustomerNode tmp = getLastNode();
                    CustomerNode newNode = new CustomerNode();
                    newNode.Customer = customerData;
                    tmp.Next = newNode;
                    return true;
                }
                else
                {
                    Console.WriteLine("The customer is already registered in the system.");
                }
            }
            return false;
        }

        // Method to search for an customer in the list by his id
        public bool searchCustomerById(int idCustomerSearch)
        {
            bool found = false;
            if (!(headCustomer == null))
            {
                CustomerNode tmp = headCustomer;
                while (tmp != null && found != true)
                {
                    if (idCustomerSearch == tmp.Customer.IdCustomer)
                    {
                        found = true;
                    }
                    else
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("The client is not registered in the system.");
            }
            return found;
        }

        // Method to search for an customer in the list by his name
        public bool searchCustomerByName(string nameCustomerSearch)
        {
            bool found = false;
            if (!(headCustomer == null))
            {
                CustomerNode tmp = headCustomer;
                while (tmp != null && found != true)
                {
                    if (nameCustomerSearch == tmp.Customer.NameCustomer)
                    {
                        found = true;
                    }
                    else
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("The client is not registered in the system.");
            }
            return found;
        }

        // Method to return an customer by his ID
        public CustomerNode returnCustomerByID(int idCustomerToReturn)
        {
            CustomerNode tmp = null;
            int count = 0;
            if (!(headCustomer == null))
            {
                if (searchCustomerById(idCustomerToReturn) == true)
                {
                    tmp = this.HeadCustomer;
                    while (count < getSize() && !(tmp.Customer.IdCustomer == idCustomerToReturn))
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            return tmp;
        }

        // Method to return an customer by his name
        public CustomerNode returnCustomerByName(string nameCustomerToReturn)
        {
            CustomerNode tmp = null;
            int count = 0;
            if (!(headCustomer == null))
            {
                if (searchCustomerByName(nameCustomerToReturn) == true)
                {
                    tmp = this.HeadCustomer;
                    while (count < getSize() && !(tmp.Customer.NameCustomer == nameCustomerToReturn))
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            return tmp;
        }

        // Method to edit the data of an customer by his ID
        public void editCustomerByID(int idCustomerToEdit, CustomerNode editedCustomer)
        {
            if (searchCustomerById(idCustomerToEdit))
            {
                CustomerNode tmp = headCustomer;
                while (tmp.Customer.IdCustomer != idCustomerToEdit)
                {
                    tmp = tmp.Next;
                }
                tmp.Customer.NameCustomer = editedCustomer.Customer.NameCustomer;
                tmp.Customer.Phone = editedCustomer.Customer.Phone;
            }
            else
            {
                Console.WriteLine("The customer to be edited cannot be found in the system.");
            }
        }

        // Method to delete an customer by his ID
        public void deleteCustomerByID(int idCustomerToDelete)
        {
            if (searchCustomerById(idCustomerToDelete))
            {
                if (headCustomer.Customer.IdCustomer == idCustomerToDelete)
                {
                    headCustomer = headCustomer.Next;
                }
                else
                {
                    CustomerNode tmp = headCustomer;
                    while (tmp.Next.Customer.IdCustomer != idCustomerToDelete)
                    {
                        tmp = tmp.Next;
                    }
                    CustomerNode next = tmp.Next.Next;
                    tmp.Next = next;
                }
            }
            else
            {
                Console.WriteLine("The customer to be deleted cannot be found in the system.");
            }
        }

        // Method to show all elements of the list
        public void listCustomers()
        {
            if (!(headCustomer == null))
            {
                CustomerNode tmp = headCustomer;
                while (tmp != null)
                {
                    tmp.Customer.showCustomerStatus();
                    tmp = tmp.Next;
                }
            }
            else
            {
                Console.WriteLine("The customer list is empty");
            }
        }
    }
}