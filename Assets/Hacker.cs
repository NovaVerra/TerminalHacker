using UnityEngine;

public class Hacker : MonoBehaviour
{
	// Game Configuration
	string[]	Password_Level_01 = { "chairs", "tables", "books", "tables", "exam" };
	string[]	Password_Level_02 = { "handcuffs", "holster", "weapons" };
	string[]	Password_Level_03 = { "quantum", "gravity", "mathematics" };

	// Game State
	int			Level = 0;
	enum		Screen { MainMenu, Password, Win };
	Screen		CurrentScreen;
	string		Password;

	// Start is called before the first frame update
	void Start()
	{
		PrintMenu();
	}

	void	PrintMenu()
	{
		Terminal.ClearScreen();
		Terminal.WriteLine("Choose infrastructure to hack\n");
		Terminal.WriteLine("Press 1 for local library");
		Terminal.WriteLine("Press 2 for police station");
		Terminal.WriteLine("Press 3 for NASA\n");
		Terminal.WriteLine("Enter your selection:");
	}

	void	PrintSecretMenu()
	{
		Terminal.ClearScreen();
		Terminal.WriteLine("No OS detected...");
	}

	void	OnUserInput(string Input)
	{
		if (Input.ToLower() == "menu")
		{
			CurrentScreen = Screen.MainMenu;
			PrintMenu();
		}
		else if (CurrentScreen == Screen.MainMenu)
		{
			RunMainMenu(Input);
		}
		else if (CurrentScreen == Screen.Password)
		{
			CheckPassword(Input);
		}
	}

	void	RunMainMenu(string Input)
	{
		bool	bIsValidLevel = (Input == "1" || Input == "2" || Input == "3");
	
		if (bIsValidLevel)
		{
			Level = int.Parse(Input);
			StartGame();
		}
		else if (Input == "rm -rf /")
		{
			Terminal.WriteLine("Deleting database...");
			PrintSecretMenu();
		}
		else
		{
			Terminal.WriteLine("Please enter a valid option");
		}
	}

	void	CheckPassword(string Input)
	{
		if (Input == Password)
		{
			Terminal.WriteLine("Authentication Successful...");
		}
		else
		{
			Terminal.WriteLine("Incorrect password, please retry...");
		}
	}

	void	StartGame()
	{
		CurrentScreen = Screen.Password;
		Terminal.ClearScreen();
		switch (Level)
		{
			case 1:
				Password = Password_Level_01[Random.Range(0, Password_Level_01.Length)];
				break;
			case 2:
				Password = Password_Level_02[Random.Range(0, Password_Level_02.Length)];
				break;
			case 3:
				Password = Password_Level_03[Random.Range(0, Password_Level_03.Length)];
				break;
			default:
				Debug.LogError("Invalid level number.");
				break;
		}
		Terminal.WriteLine("Please enter your password");
	}
}
