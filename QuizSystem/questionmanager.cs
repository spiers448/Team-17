using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizSystem
{
    public class DataManager
    {
        public List<Category> categories;
        public List<Quiz> quizzes;
        public List<Question> allQuestions;

        public DataManager()
        {
            categories = new List<Category>();
            quizzes = new List<Quiz>();
            allQuestions = new List<Question>();
            
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
            // OOP Fundamentals questions
            List<string> q1options = new List<string> { "Object-Oriented Programming", "Operational Output Processing", "Open Order Protocol", "Overloaded Operator Procedure" };
            allQuestions.Add(new Question(1, "What does OOP stand for?", q1options, "Object-Oriented Programming", "Easy"));

            List<string> q2options = new List<string> {"Encapsulation", "Polymorphism", "Abstraction", "Compilation"};
            allQuestions.Add(new Question(2,"Which of the following is NOT a core principle of OOP?",q2options,"Compilation","Easy"));

            List<string> q3options = new List<string> { "Binding data and methods", "Inheritance", "Overloading", "Creating objects" };
            allQuestions.Add(new Question(3, "What is encapsulation in object-oriented programming?", q3options, "Binding data and methods", "Medium"));

            List<string> q4options = new List<string>{"extends","inherits",":","base"};
            allQuestions.Add(new Question(4, "Which keyword is used in C# to inherit a class?", q4options, ":", "Medium"));

            List<string> q5options = new List<string> { "To destroy objects", "To initialize objects", "To inherit methods", "To override properties" };
            allQuestions.Add(new Question(5,"What is the purpose of a constructor in a class?",q5options,"To initialize objects","Easy"));

            List<string> q6options=new List<string>{"Inheritance","Polymorphism","Overloading","Encapsulation"};
            allQuestions.Add(new Question(6, "Which concept allows multiple methods with the same name but different parameters?", q6options, "Overloading", "Medium"));

            List<string> q7options = new List<string> { "System.Object", "BaseClass", "RootClass", "MainClass" };
            allQuestions.Add(new Question(7, "What is the base class for all classes in C#?", q7options, "System.Object", "Hard"));

            List<string> q8options = new List<string>{"Class is an instance, object is a blueprint","Class is a blueprint, object is an instance","They are the same","Object inherits class"};
            allQuestions.Add(new Question(8,"What is the difference between a class and an object?",q8options,"Class is a blueprint, object is an instance","Medium"));

            List<string> q9options = new List<string> { "public", "private", "protected", "internal" };
            allQuestions.Add(new Question(9, "Which access modifier makes a member accessible only within its own class?", q9options, "private", "Easy"));

            List<string> q10options=new List<string>{"Ability to hide data","Ability to inherit methods","Ability to take many forms","Ability to override constructors"};
            allQuestions.Add(new Question(10, "What is polymorphism in OOP?", q10options, "Ability to take many forms", "Medium"));
        }

        private void LoadQuizzes()
        {
            Category programmingCat = categories.FirstOrDefault(c => c.CategoryID == 1);
            
            List<Question> oopQuestions = allQuestions.Take(10).ToList();
            
            Quiz oopQuiz = new Quiz(1, "OOP Fundamentals", "Covers basics of object-oriented programming", programmingCat, oopQuestions, new DateTime(2025, 9, 1));
            quizzes.Add(oopQuiz);

            
            quizzes.Add(new Quiz(2,"Data Structures","Focuses on arrays, lists, stacks, queues, trees, and their applications.",categories[1],new List<Question>(),new DateTime(2025,9,1)));
            quizzes.Add(new Quiz(3, "Software Design", "Includes design patterns, architecture principles, and system modelling.", categories[2], new List<Question>(), new DateTime(2025, 9, 1)));
            quizzes.Add(new Quiz(4,"Web Development","HTML, CSS, JavaScript, and client-server interactions",categories[3],new List<Question>(),new DateTime(2025,9,7)));
            quizzes.Add(new Quiz(5, "Database Systems", "SQL queries, relational models, normalization, and transactions.", categories[4], new List<Question>(), new DateTime(2025, 9, 7)));
            quizzes.Add(new Quiz(6,"Cybersecurity Basics","Encryption, authentication, and common security threats",categories[5],new List<Question>(),new DateTime(2025,9,11)));
            quizzes.Add(new Quiz(7, "Computer Networks", "Protocols, IP addressing, routing, and network layers", categories[6], new List<Question>(), new DateTime(2025, 9, 13)));
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