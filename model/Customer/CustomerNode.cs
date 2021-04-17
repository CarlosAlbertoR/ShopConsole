using System;

namespace ShopConsole{
    public class CustomerNode{
        private Customer customer;
        private CustomerNode next;

        //Constructors
        public CustomerNode()
        {
            customer = new Customer();
            next = null;
        }
        public CustomerNode(Customer customer)
        {
            this.customer = customer;
        }

        //Getters and Setters
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        public CustomerNode Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}