using System;

namespace ShopConsole
{
    public class InvoiceList
    {
        public InvoiceNode headInvoice;

        //Constructors
        public InvoiceList()
        {
            headInvoice = null;
        }
        public InvoiceList(InvoiceNode headInvoice)
        {
            this.headInvoice = headInvoice;
        }

        //Getters and Setters
        public InvoiceNode HeadInvoice
        {
            get { return headInvoice; }
            set { headInvoice = value; }
        }

        /*=========================================METHODS================================*/
        // Method to get the size of the list
        public int getSize()
        {
            InvoiceNode tmp = null;
            int count = 0;
            if (this.HeadInvoice != null)
            {
                tmp = this.HeadInvoice;
                while (tmp.Next != null)
                {
                    count++;
                    tmp = tmp.Next;
                }
            }
            return count;
        }

        // Method to get the last node in the list
        public InvoiceNode getLastNode()
        {
            InvoiceNode tmp = null;
            if (this.HeadInvoice != null)
            {
                tmp = this.HeadInvoice;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
            }
            return tmp;
        }

        // Method to add a new invoice to the list
        public bool AddInvoice(Invoice invoiceData)
        {
            if (invoiceData == null)
            {
                return false;
            }
            if (headInvoice == null)
            {
                headInvoice = new InvoiceNode();
                headInvoice.Invoice = invoiceData;
            }
            else
            {
                if (searchInvoiceById(invoiceData.IdInvoice) == false)
                {
                    InvoiceNode tmp = getLastNode();
                    InvoiceNode newNode = new InvoiceNode();
                    newNode.Invoice = invoiceData;
                    tmp.Next = newNode;
                    return true;
                }
                else
                {
                    Console.WriteLine("The invoice is already registered in the system.");
                }
            }
            return false;
        }

        // Method to search for an invoice in the list by his id
        public bool searchInvoiceById(int idInvoiceSearch)
        {
            bool found = false;
            if (!(headInvoice == null))
            {
                InvoiceNode tmp = headInvoice;
                while (tmp != null && found != true)
                {
                    if (idInvoiceSearch == tmp.Invoice.IdInvoice)
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
                Console.WriteLine("The invoice is not registered in the system.");
            }
            return found;
        }

        // Method to return an invoice by his ID
        public InvoiceNode returnInvoiceByID(int idInvoiceToReturn)
        {
            InvoiceNode tmp = null;
            int count = 0;
            if (!(headInvoice == null))
            {
                if (searchInvoiceById(idInvoiceToReturn) == true)
                {
                    tmp = this.HeadInvoice;
                    while (count < getSize() && !(tmp.Invoice.IdInvoice == idInvoiceToReturn))
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            return tmp;
        }

        // Method to show all elements of the list
        public void listInvoices()
        {
            if (!(headInvoice == null))
            {
                InvoiceNode tmp = headInvoice;
                while (tmp != null)
                {
                    tmp.Invoice.showInvoiceStatus();
                    tmp = tmp.Next;
                    Console.WriteLine("================================================================================");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("The invoices list is empty");
            }
        }

        // Method to display all invoices for a customer
        public void listInvoicesByCustomer(int idCustomer)
        {
            int cont = 0;
            if (!(headInvoice == null))
            {
                InvoiceNode temp = headInvoice;
                while (temp != null)
                {
                    if (temp.Invoice.Customer.Customer.IdCustomer == idCustomer)
                    {
                        temp.Invoice.showInvoiceStatus();
                        Console.WriteLine("================================================================================");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        cont++;
                    }
                    temp = temp.Next;
                }
                if (cont == 0)
                {
                    Console.WriteLine("This customer has no registered invoices.");
                }
            }
            else
            {
                Console.WriteLine("The invoices list is empty.");
            }
        }
    }
}