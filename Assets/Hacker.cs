using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    string menuHint = "You may type menu at any time.";
    string[] level1Password = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Password = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Password = { "starfield", "telescope", "enviroment", "exploration", "astronauts" };
    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    void Start()
    {
        ShowMainMenu();

    }

    void Update()
    {

    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection: ");
    }


    void OnUserInput(string input)
    {
        if (input == "menu")//we can always go direct to main menu
        {
            ShowMainMenu();
            //TODO handle differently depending on screen
        }else if (input=="quit" || input=="close" || input=="exit")
        {
            Terminal.WriteLine("If one the web close the tab");
            Application.Quit();
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input=="3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")// estern egg
        {
            Terminal.WriteLine("Please select a level Mr Bond");
        }
        else
        {
            Terminal.WriteLine("Please chose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Password[Random.Range(0, level1Password.Length)];
                break;
            case 2:
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;
            case 3:
                password = level3Password[Random.Range(0, level3Password.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
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
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
///
/// ***
///                 ");
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine("Play again for greater challange");
                Terminal.WriteLine(@"
///
////////////
///                 ");
                break;
            case 3:
                Terminal.WriteLine(@"
///
////////////
///                 ");
                Terminal.WriteLine("Welcome to NASA");
                break;
            default:
                break;
        }
    }
}
