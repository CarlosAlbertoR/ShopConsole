using System;

namespace ShopConsole
{
    public class Invoice
    {
        private int idInvoice;
        private DateTime date;
        private CustomerNode customer;
        private ArticleList itemsList;
        private Double invoiceValue;

        //Constructores
        public Invoice()
        {
        }
        public Invoice(int idInvoice, CustomerNode customer, ArticleList itemsList, Double invoiceValue)
        {
            this.idInvoice = idInvoice;
            this.date = DateTime.Now;
            this.customer = customer;
            this.itemsList = itemsList;
            this.invoiceValue = invoiceValue;
        }

        //Getters and Setters
        public int IdInvoice
        {
            get { return idInvoice; }
        }
        public CustomerNode Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        public ArticleList ListaItems
        {
            get { return itemsList; }
            set { itemsList = value; }
        }
        public Double ValorInvoice
        {
            get { return invoiceValue; }
            set { invoiceValue = value; }
        }

        /*=========================================METHODS================================*/
        // Method to show the status of each invoice
        public void showInvoiceStatus()
        {
            Console.WriteLine("ID: {0}, Date: {1}", idInvoice, date);
            Console.WriteLine("Customer Name: {0}, Phone: {1}", customer.Customer.NameCustomer, customer.Customer.Phone);
            Console.WriteLine("Items List: ");
            itemsList.listArticlesByInvoice();
            Console.WriteLine("Total Invoice Value: {0}", itemsList.totalValue());
        }
    }
}