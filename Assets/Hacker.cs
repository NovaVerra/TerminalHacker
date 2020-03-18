using UnityEngine;

public class Hacker : MonoBehaviour
{
	/** Game Configuration */
	string[]	Password_Level_01 = { "chairs", "tables", "books", "tables", "exam" };
	string[]	Password_Level_02 = { "handcuffs", "holster", "weapons" };
	string[]	Password_Level_03 = { "quantum", "gravity", "mathematics" };

	/** Game State */
	int			Level = 0;
	enum		Screen { MainMenu, Password, Win };
	Screen		CurrentScreen;
	string		Password;

	/** Start is called before the first frame update */
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
			AskPassword();
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
			DisplayWinScreen();
		}
		else
		{
			Terminal.WriteLine("Please retry..." + Password.Anagram());
		}
	}

	void	DisplayWinScreen()
	{
		CurrentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
	}

	void	ShowLevelReward()
	{
		switch (Level)
		{
			case 1:
				Terminal.WriteLine("Have a book...");
				Terminal.WriteLine(@"
	_______
   /      /,
  /      //
 /______//
(______(/
				");
				break;
			case 2:
				Terminal.WriteLine("Have a key...");
				Terminal.WriteLine(@"
 8 8 8 8                     ,ooo.
 8a8 8a8                    oP   ?b
d888a888zzzzzzzzzzzzzzzzzzzz8     8b
 `""^""'                    ?o___oP'
				");
				break;
			case 3:
				Terminal.WriteLine("Have the launch code...");
				Terminal.WriteLine(@"
246107
				");
				break;
			default:
				Debug.LogError("Invalid level reached");
				break;
		}
	}

	void	AskPassword()
	{
		CurrentScreen = Screen.Password;
		Terminal.ClearScreen();
		SetRandomPassword();
		Terminal.WriteLine("Please enter your password");
	}

	void	SetRandomPassword()
	{
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
	}
}
