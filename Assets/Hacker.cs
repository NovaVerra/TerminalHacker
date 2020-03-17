using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		string Greeting = "Hello Leo";
		PrintMenu(Greeting);
	}
	
	void	PrintMenu(string Greeting)
	{
		Terminal.ClearScreen();
		Terminal.WriteLine(Greeting);
		Terminal.WriteLine("Choose infrastructure to hack\n");
		Terminal.WriteLine("Press 1 for local library");
		Terminal.WriteLine("Press 2 for police station");
		Terminal.WriteLine("Press 3 for NASA\n");
		Terminal.WriteLine("Enter your selection:");
	}

	void	OnUserInput(string Input)
	{
		// Terminal.WriteLine("The user typed " + Input);
		print(Input == "1");
	}
}
