using System;

namespace ShopConsole
{
    class Program
    {
        static CustomerList customerList = new CustomerList();
        static ArticleList articleList = new ArticleList();
        static InvoiceList invoiceList = new InvoiceList();
        static void Main(string[] args)
        {
            // Customer default data
            Customer customer1 = new Customer(1, "Juan", 3216573456);
            Customer customer2 = new Customer(2, "Pepito", 3218764865);
            Customer customer3 = new Customer(3, "Marco", 3146578934);
            Customer customer4 = new Customer(4, "Andres", 3135555567);
            Customer customer5 = new Customer(5, "Sandro", 3203217676);

            //Article default data
            Article article1 = new Article(1, "Celular Huawey", 13, 450000.00);
            Article article2 = new Article(2, "Televisor Samsung", 7, 1050000.00);
            Article article3 = new Article(3, "Equipo de Sonido LG", 5, 600000.00);
            Article article4 = new Article(4, "Celular Iphone X", 5, 3500000.00);
            Article article5 = new Article(5, "Celular Moto G7", 16, 750000.0);

            // Fill customers list with default data
            customerList.addCustomer(customer1);
            customerList.addCustomer(customer2);
            customerList.addCustomer(customer3);
            customerList.addCustomer(customer4);
            customerList.addCustomer(customer5);

            // Fill articles list with default data
            articleList.addArticle(article1);
            articleList.addArticle(article2);
            articleList.addArticle(article3);
            articleList.addArticle(article4);
            articleList.addArticle(article5);

            //Menu de opciones para el sistema
            int value;
            do
            {
                Console.WriteLine("1- List clients.");
                Console.WriteLine("2- List articles.");
                Console.WriteLine("3- Add a new client to the system.");
                Console.WriteLine("4- Add a new article to the system.");
                Console.WriteLine("5- Edit customer data.");
                Console.WriteLine("6- Edit the data of an article.");
                Console.WriteLine("7- Delete a client.");
                Console.WriteLine("8- Delete an article.");
                Console.WriteLine("9- List Invoices.");
                Console.WriteLine("10- Add a new invoice to the system.");
                Console.WriteLine("11- List the invoices of a customer.");
                Console.WriteLine("0- EXIT");
                Console.WriteLine("Please select an option:");
                value = Convert.ToInt32(Console.ReadLine());
                switch (value)
                {
                    case 1: customerList.listCustomers(); break;
                    case 2: articleList.listArticles(); break;
                    case 3: Customer customer = loadCustomer(); customerList.addCustomer(customer); break;
                    case 4: Article article = loadArticle(); articleList.addArticle(article); break;
                    case 5: CustomerNode customerEdit = editCustomer(); customerList.editCustomerByID(customerEdit.Customer.IdCustomer, customerEdit); break;
                    case 6: ArticleNode articleEdit = editArticle(); articleList.editArticleByID(articleEdit.Article.IdArticle, articleEdit); break;
                    case 7: deleteCustomer(customerList); break;
                    case 8: deleteArticle(articleList); break;
                    case 9: invoiceList.listInvoices(); break;
                    case 10: Invoice invoice = loadInvoice(); invoiceList.addInvoice(invoice); break;
                    case 11: invoiceList.listInvoicesByCustomer(invoiceListByCustomer()); break;
                }
                Console.Write("Press any key to continue . . .");
                Console.ReadKey();
                Console.Clear();
            } while (value != 0);
        }

        // Parameters to add a new customer
        static Customer loadCustomer()
        {
            Console.WriteLine("Enter the new customer data:");
            Console.WriteLine("Id Customer:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Customer Name:");
            String name = Console.ReadLine();
            Console.WriteLine("Customer Phone:");
            long phone = long.Parse(Console.ReadLine());
            Customer customer = new Customer(id, name, phone);
            return customer;
        }

        // Parameters to add a new article
        static Article loadArticle()
        {
            Console.WriteLine("Enter the data for the new article:");
            Console.WriteLine("Article Id:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Article Name:");
            String name = Console.ReadLine();
            Console.WriteLine("Stock Item:");
            int stock = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Item Price:");
            Double phone = Double.Parse(Console.ReadLine());
            Article article = new Article(id, name, stock, phone);
            return article;
        }

        // Parameters to add a new invoice
        static Invoice loadInvoice()
        {
            Console.WriteLine("Enter the details of the new invoice:");
            Console.WriteLine("Id Invoice:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("ID Customer:");
            int idCli = Int32.Parse(Console.ReadLine());
            CustomerNode customer = customerList.returnCustomerByID(idCli);
            Console.WriteLine("List articles:");
            ArticleList listItems = new ArticleList();
            int var = 1;
            do
            {
                Console.WriteLine("Enter the ID of the article you want to add:");
                int idA = Int32.Parse(Console.ReadLine());
                Article newArticle = articleList.returnArticleByID(idA).Article;
                Console.WriteLine("Enter the amount you want to carry:");
                int cant = Int32.Parse(Console.ReadLine());
                if (cant > newArticle.Stock)
                {
                    Console.WriteLine("Not all these drives are available.");
                    Console.WriteLine("Do you want to enter another quantity less than: {0}", newArticle.Stock, "units.");
                    Console.WriteLine("1- YES");
                    Console.WriteLine("0- NO");
                    Console.WriteLine("Please select an option:");
                    int a = Int32.Parse(Console.ReadLine());
                    if (a == 1)
                    {
                        Console.WriteLine("Enter the amount you want to carry:");
                        cant = Int32.Parse(Console.ReadLine());
                        newArticle.Quantity = cant;
                        newArticle.TotalPrice = newArticle.Quantity * newArticle.Price;
                        articleList.returnArticleByID(idA).Article.updateStock(newArticle.Stock - cant);
                        listItems.addArticle(newArticle);
                    }
                    else
                    {
                        listItems.addArticle(null);
                    }
                }
                else
                {
                    newArticle.Quantity = cant;
                    newArticle.TotalPrice = newArticle.Quantity * newArticle.Price;
                    articleList.returnArticleByID(idA).Article.updateStock(newArticle.Stock - cant);
                    listItems.addArticle(newArticle);
                }

                Console.WriteLine("You want to add another item to the invoice:");
                Console.WriteLine("1- YES");
                Console.WriteLine("0- NO");
                Console.WriteLine("Please select an option:");
                var = Int32.Parse(Console.ReadLine());
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (var != 0);
            Double valueInvoice = listItems.totalValue();
            Invoice invoice = new Invoice(id, customer, listItems, valueInvoice);
            return invoice;
        }

        // Parameters to edit a customer
        static CustomerNode editCustomer()
        {
            Console.WriteLine("Enter the ID of the client to edit:");
            Console.WriteLine("Id Customer:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new data for this customer...");
            Console.WriteLine("Customer Name:");
            String name = Console.ReadLine();
            Console.WriteLine("Customer Phone:");
            long phone = long.Parse(Console.ReadLine());
            CustomerNode customer = new CustomerNode(new Customer(id, name, phone));
            return customer;
        }

        // Parameters to edit an article
        static ArticleNode editArticle()
        {
            Console.WriteLine("Enter the ID of the article to edit:");
            Console.WriteLine("Article Id:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new data for this article...");
            Console.WriteLine("Article Name:");
            String name = Console.ReadLine();
            Console.WriteLine("Stock Item:");
            int stock = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Item Price:");
            Double price = Double.Parse(Console.ReadLine());
            ArticleNode article = new ArticleNode(new Article(id, name, stock, price));
            return article; ;
        }

        // Parameters to delete a customer
        static void deleteCustomer(CustomerList listCli)
        {
            Console.WriteLine("Enter the ID of the customer to remove: ");
            int id = Int32.Parse(Console.ReadLine());
            listCli.deleteCustomerByID(id);
        }

        // Parameters to delete an article
        static void deleteArticle(ArticleList listArt)
        {
            Console.WriteLine("Enter the ID of the item to remove:");
            int id = Int32.Parse(Console.ReadLine());
            listArt.deleteArticleByID(id);
        }

        // Parameters to list the invoices of a customer
        static int invoiceListByCustomer()
        {
            Console.WriteLine("Enter the ID of the customer whose invoices you want to see: ");
            int id = Int32.Parse(Console.ReadLine());
            return id;
        }
    }
}
