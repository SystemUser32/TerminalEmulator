using System;

namespace TerminalEmulator
{
	/// <summary>
	/// Contains methods to provide help on commands and set preferences
	/// </summary>
	public class Helper
	{
		public Helper()
		{
		}
		
		public static void DisplayHelpPanel()
		{
			string panel = @"
				help	-	Displays this screen
				ls		-	Lists all files in current directory
				cd <path>	-	Changes to the specified directory
				pwd		-	Displays the nam eof the current directory
				mkdir <name>	-	Creates a new directory <name>
				rm <name>	-	Deletes directory <name>
				cat <path>	-	Reads the contents of file <path>
				echo <arg>	-	Prints <arg> into the screen
				clear	-	Clears the screen
				history	-	Displays a list of the used commands
				
				cal	-	Displays a calendar of the current month
				uptime	-	Shows the time the machine has been running since startup
				shutdown	-	Shuts down the computer
			";
			
			Console.WriteLine(panel);
		}
	}
}
