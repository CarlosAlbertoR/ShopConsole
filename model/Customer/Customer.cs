using System;

namespace ShopConsole
{
    public class Customer
    {
        private int idCustomer;
        private String nameCustomer;
        private long phone;

        //Constructors
        public Customer()
        {
        }
        public Customer(int idCustomer, String nameCustomer, long phone)
        {
            this.idCustomer = idCustomer;
            this.nameCustomer = nameCustomer;
            this.phone = phone;
        }

        //Getters and Setters
        public int IdCustomer
        {
            get { return idCustomer; }
        }
        public String NameCustomer
        {
            get { return nameCustomer; }
            set { nameCustomer = value; }
        }
        public long Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /*============================METHODS================================================*/
        // Method to show the status of each customer
        public void showCustomerStatus()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Phone: {2}", idCustomer, nameCustomer, phone);
        }
    }
}