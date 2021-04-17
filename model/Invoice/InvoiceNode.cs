using System;

namespace ShopConsole{
    public class InvoiceNode{
        private Invoice invoice;
        private InvoiceNode next;

        //Constructores
        public InvoiceNode()
        {
            invoice = new Invoice();
            next = null;
        }
        public InvoiceNode(Invoice invoice)
        {
            this.invoice = invoice;
        }

        //Getters and Setters
        public Invoice Invoice
        {
            get { return invoice; }
            set { invoice = value; }
        }
        public InvoiceNode Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}