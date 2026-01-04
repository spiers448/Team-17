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
        Console.WriteLine("1. Add Question");
        Console.WriteLine("2. Remove Question");
        Console.WriteLine("3. Update Question");
        Console.WriteLine("4. View All Questions");
        Console.WriteLine("5. Add Category");
        Console.WriteLine("6. Remove Category");
        Console.WriteLine("7. Save Questions to CSV");
        Console.WriteLine("8. Exit");
        Console.Write("Select option: ");
        
        string choice = Console.ReadLine();
        
        switch(choice)
        {
            case "1":
                AddQuestion(data);
                break;
            case "2":
                RemoveQuestion(data);
                break;
            case "3":
                UpdateQuestion(data);
                break;
            case "4":
                ViewAllQuestions(data);
                break;
            case "5":
                AddCategory(data);
                break;
            case "6":
                RemoveCategory(data);
                break;
            case "7":
                SaveQuestionsToCSV(data);
                break;
            case "8":
                return;
        }
    }
}

public static void AddQuestion(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("=== Add New Question ===");
    
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
    data.questions.Add(newQ);
    
    Console.WriteLine("\nQuestion added successfully!");
    Console.ReadKey();
}

public static void RemoveQuestion(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("=== Remove Question ===");
    
    ViewAllQuestions(data);
    
    Console.Write("\nEnter Question ID to remove: ");
    int id = int.Parse(Console.ReadLine());
    
    Question toRemove = data.questions.FirstOrDefault(q => q.QuestionID == id);
    
    if(toRemove != null)
    {
        data.questions.Remove(toRemove);
        Console.WriteLine("Question removed!");
    }
    else
    {
        Console.WriteLine("Question not found");
    }
    
    Console.ReadKey();
}

public static void UpdateQuestion(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("=== Update Question ===");
    
    ViewAllQuestions(data);
    
    Console.Write("\nEnter Question ID to update: ");
    int id = int.Parse(Console.ReadLine());
    
    Question toUpdate = data.questions.FirstOrDefault(q => q.QuestionID == id);
    
    if(toUpdate == null)
    {
        Console.WriteLine("Question not found");
        Console.ReadKey();
        return;
    }
    
    Console.Write("New question text (leave blank to keep current): ");
    string newText = Console.ReadLine();
    if(!string.IsNullOrEmpty(newText))
        toUpdate.QuestionText = newText;
    
    Console.Write("Update correct answer? (y/n): ");
    if(Console.ReadLine().ToLower() == "y")
    {
        Console.Write("New correct answer: ");
        toUpdate.QuestionCorrectAnswer = Console.ReadLine();
    }
    
    Console.Write("Update difficulty? (y/n): ");
    if(Console.ReadLine().ToLower() == "y")
    {
        Console.Write("New difficulty: ");
        toUpdate.QuestionDifficultyLevel = Console.ReadLine();
    }
    
    Console.WriteLine("\nQuestion updated!");
    Console.ReadKey();
}

public static void ViewAllQuestions(DataLoader data)
{
    Console.WriteLine("\n=== All Questions ===");
    foreach(Question q in data.questions)
    {
        Console.WriteLine($"ID: {q.QuestionID} | {q.QuestionText} | Difficulty: {q.QuestionDifficultyLevel}");
    }
    Console.WriteLine();
}

public static void AddCategory(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("=== Add Category ===");
    
    Console.Write("Category ID: ");
    int id = int.Parse(Console.ReadLine());
    
    Console.Write("Category name: ");
    string name = Console.ReadLine();
    
    Console.Write("Category description: ");
    string desc = Console.ReadLine();
    
    Category newCat = new Category(id, name, desc);
    data.categories.Add(newCat);
    
    Console.WriteLine("\nCategory added!");
    Console.ReadKey();
}

public static void RemoveCategory(DataLoader data)
{
    Console.Clear();
    Console.WriteLine("=== Remove Category ===");
    
    foreach(Category c in data.categories)
    {
        Console.WriteLine($"{c.CategoryID}. {c.CategoryName}");
    }
    
    Console.Write("\nEnter Category ID to remove: ");
    int id = int.Parse(Console.ReadLine());
    
    Category toRemove = data.categories.FirstOrDefault(c => c.CategoryID == id);
    
    if(toRemove != null)
    {
        data.categories.Remove(toRemove);
        Console.WriteLine("Category removed!");
    }
    else
    {
        Console.WriteLine("Category not found");
    }
    
    Console.ReadKey();
}

public static void SaveQuestionsToCSV(DataLoader data)
{
    try
    {
        List<string> lines = new List<string>();
        lines.Add("QuestionID,QuestionText,Option1,Option2,Option3,Option4,CorrectAnswer,Difficulty");
        
        foreach(Question q in data.questions)
        {
            string line = $"{q.QuestionID},\"{q.QuestionText}\",";
            foreach(string opt in q.QuestionOptions)
            {
                line += $"\"{opt}\",";
            }
            line += $"\"{q.QuestionCorrectAnswer}\",{q.QuestionDifficultyLevel}";
            lines.Add(line);
        }
        
        File.WriteAllLines("questions.csv", lines);
        Console.WriteLine("Questions saved to questions.csv successfully!");
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Error saving: {ex.Message}");
    }
    
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



