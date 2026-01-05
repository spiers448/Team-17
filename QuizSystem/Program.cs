using QuizSystem;
using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

public class Program
{

    // Starting point for the application
    public static void Main()
    {
        List<User> users = new List<User>();
        users = LoadUsers();
        LoginSequence(users);
    }

    //login method
    public static void LoginSequence(List<User> allUsers)
    {
        //prompt user for their username
        Console.WriteLine("Enter username:");
        string nameInput = Console.ReadLine();

        //prompt user for password
        Console.WriteLine("Enter password:");
        string passwordInput = Console.ReadLine();

        //check if user exists in list
        User foundUser = allUsers.FirstOrDefault(u => u.UserName == nameInput);

        //if user doesnt exist
        if (foundUser == null)
        {
            //inform user
            Console.WriteLine("Username or password incorrect");
            return;
        }

        //authenticate user details
        bool isSuccessful = foundUser.Login(nameInput, passwordInput);

        if (isSuccessful)
        {

            //inform user that login was successful
            Console.WriteLine("Login successful");

            //determine if user is a normal user or an admin user
            switch (foundUser.Role)
            {
                case UserRole.Admin:
                    ShowAdminMenu();
                    break;
                case UserRole.User:
                    ShowUserMenu();
                    break;
            }

        }
    }
    
    //admin user menu method
  //admin user menu method

public static void ShowAdminMenu()
{
    DataLoader data = new DataLoader();
    
    while(true)
    {
        Console.Clear();
        Console.WriteLine("=== Admin Menu ===");
        Console.WriteLine("1. Choose Category");
        Console.WriteLine("2. Create Category");
        Console.WriteLine("3. Exit");
        Console.Write("Select option: ");
        
        string choice = Console.ReadLine();
        
        switch(choice)
        {
            case "1":
                ChooseCategory(data);
                break;
            case "2":
                AddCategory(data);
                break;
            case "3":
                return;
        }
    }
}

public static void ChooseCategory(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("=== Select Category ===");
    
    for(int i=0; i<data.categories.Count; i++)
    {
        Console.WriteLine($"{i+1}. {data.categories[i].CategoryName}");
    }
    
    Console.Write("\nSelect category number: ");
    int catNum = int.Parse(Console.ReadLine()) - 1;
    
    if(catNum < 0 || catNum >= data.categories.Count)
    {
        Console.WriteLine("Invalid selection");
        Console.ReadKey();
        return;
    }
    
    Category selectedCat = data.categories[catNum];
    CategoryMenu(data, selectedCat);
}

public static void CategoryMenu(DataLoader data, Category category)
{
    while(true)
    {
        Console.Clear();
        Console.WriteLine($"=== {category.CategoryName} ===");
        Console.WriteLine("1. Manage Existing Quizzes");
        Console.WriteLine("2. Create New Quiz");
        Console.WriteLine("3. Back");
        Console.Write("Select option: ");
        
        string choice = Console.ReadLine();
        
        switch(choice)
        {
            case "1":
                ManageExistingQuizzes(data, category);
                break;
            case "2":
                CreateNewQuiz(data, category);
                break;
            case "3":
                return;
        }
    }
}

public static void ManageExistingQuizzes(DataLoader data, Category category)
{
    var categoryQuizzes = data.quizzes.Where(q => q.QuizCategory.CategoryID == category.CategoryID).ToList();
    
    if(categoryQuizzes.Count == 0)
    {
        Console.WriteLine("No quizzes in this category yet.");
        Console.ReadKey();
        return;
    }
    
    Console.Clear();
    Console.WriteLine($"=== Quizzes in {category.CategoryName} ===");
    for(int i=0; i<categoryQuizzes.Count; i++)
    {
        Console.WriteLine($"{i+1}. {categoryQuizzes[i].QuizTitle}");
    }
    
    Console.Write("\nSelect quiz: ");
    int quizNum = int.Parse(Console.ReadLine()) - 1;
    
    if(quizNum < 0 || quizNum >= categoryQuizzes.Count)
    {
        Console.WriteLine("Invalid selection");
        Console.ReadKey();
        return;
    }
    
    Quiz selectedQuiz = categoryQuizzes[quizNum];
    ManageQuiz(data, selectedQuiz);
}

public static void ManageQuiz(DataLoader data, Quiz quiz)
{
    while(true)
    {
        Console.Clear();
        Console.WriteLine($"=== {quiz.QuizTitle} ===");
        Console.WriteLine("1. Add Question");
        Console.WriteLine("2. Remove Question");
        Console.WriteLine("3. View Questions");
        Console.WriteLine("4. Delete Quiz");
        Console.WriteLine("5. Back");
        Console.Write("Select option: ");
        
        string choice = Console.ReadLine();
        
        switch(choice)
        {
            case "1":
                AddQuestionToQuiz(data, quiz);
                break;
            case "2":
                RemoveQuestionFromQuiz(data, quiz);
                break;
            case "3":
                ViewQuizQuestions(quiz);
                break;
            case "4":
                DeleteQuiz(data, quiz);
                return;
            case "5":
                return;
        }
    }
}

public static void CreateNewQuiz(DataLoader data, Category category)
{
    Console.Clear();
    Console.WriteLine("=== Create New Quiz ===");
    
    Console.Write("Quiz ID: ");
    int id = int.Parse(Console.ReadLine());
    
    Console.Write("Quiz title: ");
    string title = Console.ReadLine();
    
    Console.Write("Quiz description: ");
    string desc = Console.ReadLine();
    
    Quiz newQuiz = new Quiz(id, title, desc, DateTime.Now, new List<Question>(), category);
    data.quizzes.Add(newQuiz);
    
    Console.WriteLine("\nQuiz created!");
    Console.ReadKey();
    
    ManageQuiz(data, newQuiz);
}

public static void AddQuestionToQuiz(DataLoader data, Quiz quiz)
{
    Console.Clear();
    Console.WriteLine("=== Add Question ===");
    
    Console.Write("Question ID: ");
    int id = int.Parse(Console.ReadLine());
    
    Console.Write("Question text: ");
    string text = Console.ReadLine();
    
    List<string> options = new List<string>();
    for(int i=1; i<=4; i++)
    {
        Console.Write($"Option {i}: ");
        options.Add(Console.ReadLine());
    }
    
    Console.Write("Correct answer: ");
    string correctAnswer = Console.ReadLine();
    
    Console.Write("Difficulty (Easy/Medium/Hard): ");
    string difficulty = Console.ReadLine();
    
    Question newQ = new Question(id, text, options, correctAnswer, difficulty);
    quiz.QuizQuestions.Add(newQ);
    
    Console.WriteLine("\nQuestion added!");
    Console.ReadKey();
}

public static void RemoveQuestionFromQuiz(DataLoader data, Quiz quiz)
{
    if(quiz.QuizQuestions.Count == 0)
    {
        Console.WriteLine("No questions in this quiz.");
        Console.ReadKey();
        return;
    }
    
    Console.Clear();
    Console.WriteLine("=== Remove Question ===");
    
    for(int i=0; i<quiz.QuizQuestions.Count; i++)
    {
        Console.WriteLine($"{i+1}. {quiz.QuizQuestions[i].QuestionText}");
    }
    
    Console.Write("\nSelect question to remove: ");
    int qNum = int.Parse(Console.ReadLine()) - 1;
    
    if(qNum >= 0 && qNum < quiz.QuizQuestions.Count)
    {
        quiz.QuizQuestions.RemoveAt(qNum);
        Console.WriteLine("Question removed!");
    }
    else
    {
        Console.WriteLine("Invalid selection");
    }
    
    Console.ReadKey();
}

public static void ViewQuizQuestions(Quiz quiz)
{
    Console.Clear();
    Console.WriteLine($"=== {quiz.QuizTitle} Questions ===");
    
    if(quiz.QuizQuestions.Count == 0)
    {
        Console.WriteLine("No questions in this quiz.");
    }
    else
    {
        for(int i=0; i<quiz.QuizQuestions.Count; i++)
        {
            Question q = quiz.QuizQuestions[i];
            Console.WriteLine($"\n{i+1}. {q.QuestionText}");
            for(int j=0; j<q.QuestionOptions.Count; j++)
            {
                Console.WriteLine($"   {j+1}) {q.QuestionOptions[j]}");
            }
            Console.WriteLine($"   Correct: {q.QuestionCorrectAnswer}");
            Console.WriteLine($"   Difficulty: {q.QuestionDifficultyLevel}");
        }
    }
    
    Console.ReadKey();
}

public static void DeleteQuiz(DataLoader data, Quiz quiz)
{
    Console.Write($"Delete '{quiz.QuizTitle}'? (y/n): ");
    if(Console.ReadLine().ToLower() == "y")
    {
        data.quizzes.Remove(quiz);
        Console.WriteLine("Quiz deleted!");
        Console.ReadKey();
    }
}

public static void AddCategory(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("=== Create Category ===");
    
    Console.Write("Category ID: ");
    int id = int.Parse(Console.ReadLine());
    
    Console.Write("Category name: ");
    string name = Console.ReadLine();
    
    Console.Write("Category description: ");
    string desc = Console.ReadLine();
    
    Category newCat = new Category(id, name, desc);
    data.categories.Add(newCat);
    
    Console.WriteLine("\nCategory created!");
    Console.ReadKey();
}


    //normal user menu method
    //normal user menu method
public static void ShowUserMenu()
{
    DataLoader data = new DataLoader();
    
    while(true)
    {
        Console.Clear();
        Console.WriteLine("=== Student Menu ===");
        Console.WriteLine("1. Take a Quiz");
        Console.WriteLine("2. Exit");
        Console.Write("Select option: ");
        
        string choice = Console.ReadLine();
        
        if(choice == "1")
        {
            TakeQuiz(data);
        }
        else if(choice == "2")
        {
            break;
        }
    }
}
    
public static void TakeQuiz(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("Available Quizzes:");
    
    for(int i=0; i<data.quizzes.Count; i++)
    {
        Quiz q = data.quizzes[i];
        Console.WriteLine($"{i+1}. {q.QuizTitle} - {q.QuizDescription}");
    }
    
    Console.Write("\nSelect quiz number: ");
    string input = Console.ReadLine();
    int quizNum;
    
    if(!int.TryParse(input, out quizNum) || quizNum < 1 || quizNum > data.quizzes.Count)
    {
        Console.WriteLine("Invalid selection");
        Console.ReadKey();
        return;
    }
    
    Quiz selectedQuiz = data.quizzes[quizNum - 1];
    
    if(selectedQuiz.QuizQuestions.Count == 0)
    {
        Console.WriteLine("This quiz has no questions available yet.");
        Console.ReadKey();
        return;
    }
    
    int score = 0;
    
    for(int i=0; i < selectedQuiz.QuizQuestions.Count; i++)
    {
        Console.Clear();
        Question q = selectedQuiz.QuizQuestions[i];
        
        Console.WriteLine($"Question {i+1}/{selectedQuiz.QuizQuestions.Count}");
        Console.WriteLine(q.QuestionText);
        Console.WriteLine();
        
        for(int j=0; j<q.QuestionOptions.Count; j++)
        {
            Console.WriteLine($"{j+1}. {q.QuestionOptions[j]}");
        }
        
        Console.Write("\nYour answer (1-4): ");
        string ans = Console.ReadLine();
        int ansNum;
        
        if(int.TryParse(ans, out ansNum) && ansNum >= 1 && ansNum <= q.QuestionOptions.Count)
        {
            string selectedAnswer = q.QuestionOptions[ansNum - 1];
            
            if(selectedAnswer.Equals(q.QuestionCorrectAnswer, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong. Correct answer: {q.QuestionCorrectAnswer}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input - marked as wrong");
        }
        
        Console.WriteLine("\nPress any key for next question...");
        Console.ReadKey();
    }
    
    Console.Clear();
    Console.WriteLine("=== Quiz Complete ===");
    Console.WriteLine($"Your score: {score}/{selectedQuiz.QuizQuestions.Count}");
    double percent = ((double)score / selectedQuiz.QuizQuestions.Count) * 100;
    Console.WriteLine($"Percentage: {percent:F1}%");
    Console.WriteLine("\nPress any key to return to menu...");
    Console.ReadKey();
}

    //obtain data from csv file method
    public static List<User> LoadUsers()
    {
        string filename = "users.csv";

        //does the file exisit within the working dir
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found");
            fileCreate(@"users.csv");
        }

        //LINQ query
        List<User> _users = File.ReadAllLines(filename)
            .Skip(1) //skip header row
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(line =>
            {
                string[] columns = line.Split(','); //split line by comma
                                                    // role is in column 3
                UserRole parsedRole = (UserRole)Enum.Parse(typeof(UserRole), columns[3]);

                //default constructor
                return new User
                {
                    UserId = int.Parse(columns[0]),
                    UserName = columns[1],
                    Password = columns[2],
                    Role = parsedRole,
                    ContactInfo = columns[4]
                };

            }).ToList();
        return _users;
    }

    //create file and folder if not found
    public static void fileCreate(string path)
    {
        try
        {
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path));
            Console.WriteLine($"New file created at {path}");

            //create list of data to be added to csv
            var data = new List<string[]>
            {
                //for top row
                new[] { "UserID", "Username", "Password", "Access", "ContactInfo" },
                
                //admin login
                new[] { "1", "admin", "password1", "Admin", "example123@gmail.com" }
            };
            
            //write list to csv
            File.WriteAllLines("users.csv", data.Select(line => string.Join(",", line)));

            //inform user
            Console.WriteLine($"Dummy login credentials added to csv\n");
        }

        catch (Exception ex)
        {
            Console.WriteLine($"ERROR CREATING FILE/FOLDER: {ex.ToString()}");
        }
    }
}



