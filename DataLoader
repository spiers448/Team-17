using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizSystem
{
    public class DataLoader
    {
        public List<Category> categories;
        public List<Quiz> quizzes;
        public List<Question> questions;

        public DataLoader()
        {
            categories = new List<Category>();
            quizzes = new List<Quiz>();
            questions = new List<Question>();
            
            LoadCategories();
            LoadQuestions();
            LoadQuizzes();
        }

        private void LoadCategories()
        {
            categories.Add(new Category(1, "Programming Concepts", "Concepts of object-oriented programming and coding principles"));
            categories.Add(new Category(2, "Data Structures", "Arrays, lists, stacks, queues, trees, and their applications"));
            categories.Add(new Category(3,"Software Design","Design patterns, architecture principles, and system modelling"));
            categories.Add(new Category(4, "Web Development", "HTML, CSS, JavaScript, and client-server interactions"));
            categories.Add(new Category(5, "Database Systems", "SQL queries, relational models, normalization, and transactions"));
            categories.Add(new Category(6,"Cybersecurity Basics","Encryption, authentication, and common security threats"));
            categories.Add(new Category(7, "Computer Networks", "Protocols, IP addressing, routing, and network layers"));
        }

        private void LoadQuestions()
        {
            List<string> q1opts = new List<string> { "Object-Oriented Programming", "Operational Output Processing", "Open Order Protocol", "Overloaded Operator Procedure" };
            questions.Add(new Question(1, "What does OOP stand for?", q1opts, "Object-Oriented Programming", "Easy"));

            List<string> q2opts = new List<string> {"Encapsulation", "Polymorphism", "Abstraction", "Compilation"};
            questions.Add(new Question(2,"Which of the following is NOT a core principle of OOP?",q2opts,"Compilation","Easy"));

            List<string> q3opts = new List<string> { "Binding data and methods", "Inheritance", "Overloading", "Creating objects" };
            questions.Add(new Question(3, "What is encapsulation in object-oriented programming?", q3opts, "Binding data and methods", "Medium"));

            List<string> q4opts = new List<string>{"extends","inherits",":","base"};
            questions.Add(new Question(4, "Which keyword is used in C# to inherit a class?", q4opts, ":", "Medium"));

            List<string> q5opts = new List<string> { "To destroy objects", "To initialize objects", "To inherit methods", "To override properties" };
            questions.Add(new Question(5,"What is the purpose of a constructor in a class?",q5opts,"To initialize objects","Easy"));

            List<string> q6opts=new List<string>{"Inheritance","Polymorphism","Overloading","Encapsulation"};
            questions.Add(new Question(6, "Which concept allows multiple methods with the same name but different parameters?", q6opts, "Overloading", "Medium"));

            List<string> q7opts = new List<string> { "System.Object", "BaseClass", "RootClass", "MainClass" };
            questions.Add(new Question(7, "What is the base class for all classes in C#?", q7opts, "System.Object", "Hard"));

            List<string> q8opts = new List<string>{"Class is an instance, object is a blueprint","Class is a blueprint, object is an instance","They are the same","Object inherits class"};
            questions.Add(new Question(8,"What is the difference between a class and an object?",q8opts,"Class is a blueprint, object is an instance","Medium"));

            List<string> q9opts = new List<string> { "public", "private", "protected", "internal" };
            questions.Add(new Question(9, "Which access modifier makes a member accessible only within its own class?", q9opts, "private", "Easy"));

            List<string> q10opts=new List<string>{"Ability to hide data","Ability to inherit methods","Ability to take many forms","Ability to override constructors"};
            questions.Add(new Question(10, "What is polymorphism in OOP?", q10opts, "Ability to take many forms", "Medium"));
        }

        private void LoadQuizzes()
        {
            Category progCat = categories.FirstOrDefault(c => c.CategoryID == 1);
            
            List<Question> oopQuestions = questions.Take(10).ToList();
            
            Quiz oopQuiz = new Quiz(1, "OOP Fundamentals", "Covers basics of object-oriented programming", new DateTime(2025, 9, 1), oopQuestions, progCat);
            quizzes.Add(oopQuiz);

            quizzes.Add(new Quiz(2,"Data Structures","Focuses on arrays, lists, stacks, queues, trees, and their applications.",new DateTime(2025,9,1),new List<Question>(),categories[1]));
            quizzes.Add(new Quiz(3, "Software Design", "Includes design patterns, architecture principles, and system modelling.", new DateTime(2025, 9, 1), new List<Question>(), categories[2]));
            quizzes.Add(new Quiz(4,"Web Development","HTML, CSS, JavaScript, and client-server interactions",new DateTime(2025,9,7),new List<Question>(),categories[3]));
            quizzes.Add(new Quiz(5, "Database Systems", "SQL queries, relational models, normalization, and transactions.", new DateTime(2025, 9, 7), new List<Question>(), categories[4]));
            quizzes.Add(new Quiz(6,"Cybersecurity Basics","Encryption, authentication, and common security threats",new DateTime(2025,9,11),new List<Question>(),categories[5]));
            quizzes.Add(new Quiz(7, "Computer Networks", "Protocols, IP addressing, routing, and network layers", new DateTime(2025, 9, 13), new List<Question>(), categories[6]));
        }

        public Category GetCategoryByID(int id)
        {
            return categories.FirstOrDefault(c => c.CategoryID == id);
        }

        public Quiz GetQuizByID(int id)
        {
            return quizzes.FirstOrDefault(q => q.QuizID == id);
        }
    }
}