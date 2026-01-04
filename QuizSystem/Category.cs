using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class Category
    {
        
        private int categoryID;
        private string categoryName;
        private string categoryDescription;
        
    
        public int CategoryID
        {
            get { return categoryID; }
        }
        
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
        
        public string CategoryDescription
        {
            get { return categoryDescription; }
            set { categoryDescription = value; }
        }
        
        //default constructor
        public Category()
        {
        }
        
        //constructor
        public Category(int categoryID, string categoryName, string categoryDescription)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
            this.categoryDescription = categoryDescription;
        }
    }
}