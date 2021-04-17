using System;

namespace ShopConsole
{
    public class ArticleList
    {
        public ArticleNode headArticle;

        //Constructors
        public ArticleList()
        {
            headArticle = null;
        }
        public ArticleList(ArticleNode headArticle)
        {
            this.headArticle = headArticle;
        }

        //Getters and Setters
        public ArticleNode HeadArticle
        {
            get { return headArticle; }
            set { headArticle = value; }
        }

        /*=========================================METHODS================================*/
        // Method to get the size of the list
        public int getSize()
        {
            ArticleNode tmp = null;
            int count = 0;
            if (this.HeadArticle != null)
            {
                tmp = this.HeadArticle;
                while (tmp.Next != null)
                {
                    count++;
                    tmp = tmp.Next;
                }
            }
            return count;
        }

        // Method to get the last node in the list
        public ArticleNode getLastNode()
        {
            ArticleNode tmp = null;
            if (this.HeadArticle != null)
            {
                tmp = this.HeadArticle;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
            }
            return tmp;
        }

        // Method to add a new article to the list
        public bool AddArticle(Article articleData)
        {
            if (articleData == null)
            {
                return false;
            }
            if (headArticle == null)
            {
                headArticle = new ArticleNode();
                headArticle.Article = articleData;
            }
            else
            {
                if (searchArticleById(articleData.IdArticle) == false)
                {
                    ArticleNode tmp = getLastNode();
                    ArticleNode newNode = new ArticleNode();
                    newNode.Article = articleData;
                    newNode.Previous = tmp;
                    tmp.Next = newNode;
                    return true;
                }
                else
                {
                    Console.WriteLine("The article is already registered in the system.");
                }
            }
            return false;
        }

        // Method to search for an article in the list by its id
        public bool searchArticleById(int idArticleSearch)
        {
            bool found = false;
            if (!(headArticle == null))
            {
                ArticleNode tmp = headArticle;
                while (tmp != null && found != true)
                {
                    if (idArticleSearch == tmp.Article.IdArticle)
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

        // Method to search for an article in the list by its name
        public bool searchArticleByName(string nameArticleSearch)
        {
            bool found = false;
            if (!(headArticle == null))
            {
                ArticleNode tmp = headArticle;
                while (tmp != null && found != true)
                {
                    if (nameArticleSearch == tmp.Article.NameArticle)
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

        // Method to return an article by its ID
        public ArticleNode returnArticleByID(int idArticleToReturn)
        {
            ArticleNode tmp = null;
            int count = 0;
            if (!(headArticle == null))
            {
                if (searchArticleById(idArticleToReturn) == true)
                {
                    tmp = this.HeadArticle;
                    while (count < getSize() && !(tmp.Article.IdArticle == idArticleToReturn))
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            return tmp;
        }

        // Method to return an article by its name
        public ArticleNode returnArticleByName(string nameArticleToReturn)
        {
            ArticleNode tmp = null;
            int count = 0;
            if (!(headArticle == null))
            {
                if (searchArticleByName(nameArticleToReturn) == true)
                {
                    tmp = this.HeadArticle;
                    while (count < getSize() && !(tmp.Article.NameArticle == nameArticleToReturn))
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            return tmp;
        }

        // Method to edit the data of an article by its ID
        public void editArticleByID(int idArticleToEdit, ArticleNode editedArticle)
        {
            if (searchArticleById(idArticleToEdit))
            {
                ArticleNode tmp = headArticle;
                while (tmp.Article.IdArticle != idArticleToEdit)
                {
                    tmp = tmp.Next;
                }
                tmp.Article.NameArticle = editedArticle.Article.NameArticle;
                tmp.Article.Stock = editedArticle.Article.Stock;
                tmp.Article.Price = editedArticle.Article.Price;
            }
            else
            {
                Console.WriteLine("The article to be edited cannot be found in the system.");
            }
        }

        // Method to delete an article by its ID
        public void deleteArticleByID(int idArticleToDelete)
        {
            if (searchArticleById(idArticleToDelete))
            {
                if (headArticle.Article.IdArticle == idArticleToDelete)
                {
                    headArticle.Next.Previous = null;
                    headArticle = headArticle.Next;
                }
                else
                {
                    ArticleNode tmp = headArticle;
                    while (tmp.Next.Article.IdArticle != idArticleToDelete)
                    {
                        tmp = tmp.Next;
                    }
                    ArticleNode next = tmp.Next.Next;
                    next.Previous = tmp;
                    tmp.Next = next;
                }
            }
            else
            {
                Console.WriteLine("The article to be deleted cannot be found in the system.");
            }
        }

        // Method to show all elements of the list
        public void listArticles()
        {
            if (!(headArticle == null))
            {
                ArticleNode tmp = headArticle;
                while (tmp != null)
                {
                    tmp.Article.showArticleStatus();
                    tmp = tmp.Next;
                }
            }
            else
            {
                Console.WriteLine("The article list is empty");
            }
        }

        // Method to show all the elements of the list for invoice
        public void listArticlesByInvoice()
        {
            if (!(headArticle == null))
            {
                ArticleNode tmp = headArticle;
                while (tmp != null)
                {
                    tmp.Article.itemStatusByInvoice();
                    tmp = tmp.Next;
                }
            }
            else
            {
                Console.WriteLine("This invoice is empty.");
            }
        }

        // Method to obtain the total value of the items in the list
        public Double totalValue()
        {
            Double count = 0;
            if (!(headArticle == null))
            {
                ArticleNode tmp = headArticle;
                while (tmp != null)
                {
                    count += tmp.Article.TotalPrice;
                    tmp = tmp.Next;
                }
            }
            return count;
        }
    }
}