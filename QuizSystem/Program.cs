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
    public static void ShowAdminMenu()
    {
        //clear console between menus
        Console.Clear();            //personally, i think the ui is much easier to navigate 
        Console.WriteLine("admin"); //if we clear the term between menus, but we dont have to do this if you all disagree
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



