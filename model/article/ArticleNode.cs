using System;

namespace ShopConsole
{
    public class ArticleNode
    {
        private Article article;
        private ArticleNode next;
        private ArticleNode previous;

        //Constructors
        public ArticleNode()
        {
            article = new Article();
            next = previous = null;
        }
        public ArticleNode(Article article)
        {
            this.article = article;
        }

        //Getters and Setters
        public Article Article
        {
            get { return this.article; }
            set { article = value; }
        }
        public ArticleNode Next
        {
            get { return this.next; }
            set { next = value; }
        }
        public ArticleNode Previous
        {
            get { return this.previous; }
            set { previous = value; }
        }
    }
}