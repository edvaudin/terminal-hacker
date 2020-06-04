using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] level1Passwords = { "books", "shelf", "aisle", "local", "stamp" };
    string[] level2Passwords = { "arrest", "police", "taser", "prisoner", "holster" };
    string[] level3Passwords = { "nitrogen", "oxygen", "helium", "mercury", "carbon" };
    const string menuHint = "If you want to go back, type menu";
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the terminal.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Select a level:");
        Terminal.WriteLine("Type 1 for Stanton Library.");
        Terminal.WriteLine("Type 2 for Stanton Prison.");
        Terminal.WriteLine("Type 3 for NASA.");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please select a valid target.");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter password (hint: " + password.Anagram() + "): ");
        Terminal.WriteLine(menuHint); 
    }
    
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine("Password correct!");
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.ClearScreen();
                Terminal.WriteLine("Welcome to the library");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
          ");
                break;
            case 2:
                Terminal.ClearScreen();
                Terminal.WriteLine("Welcome to prison");
                Terminal.WriteLine(@"
         ALCATRAZ  /__\ 
       ____________|  |
       |_|_|_|_|_|_|  |
       |_|_|_|_|_|_|__| 
      A@\|_|_|_|_|_|/@@Aa
   aaA@@@@@@@@@@@@@@@@@@@aaaA

");
                
                break;
            case 3:
                Terminal.ClearScreen();
                Terminal.WriteLine("Welcome to NASA");
                Terminal.WriteLine(@"
       ()    .-.,=``=.  - o -
             '=/_      \     |
          *   | '=._    |
               \     `=./`, '
            .   '=.__.=' `= '      *
   + +
        O * '       . 
");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
