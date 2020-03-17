using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
	// Game State
	int	Level = 0;

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

	void	OnUserInput(string Input)
	{
		if (Input == "1")
		{
			Level = 1;
			StartGame();
		}
		else if (Input == "2")
		{
			Level = 2;
			StartGame();
		}
		else if (Input == "3")
		{
			Level = 3;
			StartGame();
		}
		else if (Input.ToLower() == "menu")
		{
			PrintMenu();
		}
		else if (Input == "rm -rf /")
		{
			Terminal.WriteLine("Are you sure you want to delete the database?");
		}
		else
		{
			Terminal.WriteLine("Please enter a valid option");
		}
	}

	void	StartGame()
	{
		Terminal.WriteLine("You've chosen level: " + Level);
	}
}
