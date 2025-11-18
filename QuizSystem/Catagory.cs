using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class Category
    {
        //private fields
        private int categoryID;
        private string categoryName;
        private string categoryDescription;

        //public properties
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
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

        //constructor
        public Category(int categoryID, string categoryName, string categoryDescription)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
            this.categoryDescription = categoryDescription;
        }

    }
}
