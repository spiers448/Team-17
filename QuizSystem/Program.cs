using QuizSystem;

public class Program
{


    // Starting point for the application
    public static void Main()
    {
        List<User> users = new List<User>();
        users = LoadUsers();
        LoginSequence(users);
    }

    public static void LoginSequence(List<User> allUsers)
    {
        Console.WriteLine("Enter username:");
        string nameInput = Console.ReadLine();

        Console.WriteLine("Enter password:");
        string passwordInput = Console.ReadLine();

        //check if user exists in list
        User foundUser = allUsers.FirstOrDefault(u => u.UserName == nameInput);

        //if user doesnt exist
        if (foundUser == null)
        {
            Console.WriteLine("Username or password incorrect");
            return;
        }

        //authenticate user details
        bool isSuccessful = foundUser.Login(nameInput, passwordInput);

        if (isSuccessful)
        {
            Console.WriteLine("Login successful");

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

    public static void ShowAdminMenu()
    {
        Console.WriteLine("admin");
    }

    public static void ShowUserMenu()
    {
        Console.WriteLine("user");
    }


    public static List<User> LoadUsers()
    {
        string filename = "users.csv";

        //does the file exisit within the working dir
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found");
            return new List<User>();
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



}