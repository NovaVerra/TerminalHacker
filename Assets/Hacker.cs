using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
	// Game Configuration
	string[]	Password_Level_01 = { "chairs", "tables", "books", "tables", "exam" };
	string[]	Password_Level_02 = { "handcuffs", "holster", "weapons" };
	string[]	Password_Level_03 = { "quantum", "gravity", "mathematics" };
	Random		Rand = new Random();
	int			Index = Rand.Next();

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
		if (Input == "1")
		{
			Level = 1;
			Password = Password_Level_01[0];
			StartGame();
		}
		else if (Input == "2")
		{
			Level = 2;
			Password = Password_Level_02[0];
			StartGame();
		}
		else if (Input == "3")
		{
			Level = 3;
			Password = Password_Level_03[0];
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
		Terminal.WriteLine("You've chosen level: " + Level);
		Terminal.WriteLine("Please enter your password");
	}
}
