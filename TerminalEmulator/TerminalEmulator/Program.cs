using System;

namespace TerminalEmulator
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Terminal terminal = new Terminal();
			terminal.Start();
			
			int historyIndex = 0;
			
			if(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.UpArrow)
			{
				if(historyIndex > 0)
				{
					historyIndex--;
					Console.Write(terminal.commandsHistory[historyIndex]);
				}
			}
			
		}
	}
}

