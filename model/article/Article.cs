using System;

namespace ShopConsole
{
    public class Article
    {
        private int idArticle;
        private string nameArticle;
        private int stock;
        private int quantity;
        private Double price;
        private Double totalPrice;

        //Constructors
        public Article() { }
        public Article(int idArticle, string nameArticle, int stock, Double price)
        {
            this.idArticle = idArticle;
            this.nameArticle = nameArticle;
            this.stock = stock;
            this.quantity = 0;
            this.price = price;
            this.totalPrice = 0;
        }

        //Getters and Setters
        public int IdArticle
        {
            get { return this.idArticle; }
        }
        public string NameArticle
        {
            get { return this.nameArticle; }
            set { this.nameArticle = value; }
        }
        public int Stock
        {
            get { return this.stock; }
            set { stock = value; }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { quantity = value; }
        }
        public Double Price
        {
            get { return this.price; }
            set { price = value; }
        }
        public Double TotalPrice
        {
            get { return this.totalPrice; }
            set { totalPrice = value; }
        }

        /*============================METHODS================================================*/
        // Method to show the status of each article
        public void showArticleStatus()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Stock: {2}, Price: {3}", idArticle, nameArticle, stock, price);
        }

        // Method to update the stock value of an item
        public void updateStock(int newStock)
        {
            stock = newStock;
        }

        // Method for the status of the item in the invoice
        public void itemStatusByInvoice()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Price: {2}, Quantity: {3}, Total Price: {4}", idArticle, nameArticle, price, quantity, totalPrice);
        }
    }
}