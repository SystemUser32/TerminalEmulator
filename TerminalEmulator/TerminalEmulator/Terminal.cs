using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace TerminalEmulator
{
	/// <summary>
	/// Description of Terminal.
	/// </summary>
	public class Terminal
	{
		
		public List<string> commandsHistory;
		
		public Terminal()
		{
			commandsHistory = new List<string>();
		}
		
		public void Start()
    	{
        	while (true)
        	{
        	    Console.Write("$ ");
        	    string input = Console.ReadLine();

        	    if (input == "exit")
        	        break;
        	    
        	    commandsHistory.Add(input);

        	    string[] commands = input.Split(' ');
        	    
        	    // I should have organized this into separate functions
        		switch (commands[0])
        		{
        			case "help":
        				Helper.DisplayHelpPanel();
        				break;
        				
            			
        			case "ls":
                		string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
                		string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
                		
                		foreach(string dir in dirs)
                		{
                			Console.WriteLine(Path.GetFileName(dir));
                		}
                		
    					foreach (string file in files)
    					{
        					Console.WriteLine(Path.GetFileName(file));
    					}
    					
                		break;
                		
            		
                	case "cd":
                		if(commands.Length < 2)
                		{
                			Console.WriteLine("Invalid argument - Usage: cd <directory>");
                			break;
                		}
                		
                		try
                		{
                			string dir = Path.GetFullPath(commands[1]);
                			Directory.SetCurrentDirectory(dir);
                		}
                		catch(Exception ex)
                		{
                			Console.WriteLine("Error: {0}", ex.Message);
                		}
                		
                		break;
                	
                		
            		case "pwd":
                		string workingDir = Directory.GetCurrentDirectory();
                		Console.WriteLine(Path.GetFileName(workingDir));
                		
                		break;
                		
            		
                	case "mkdir":
                		string dirName = input.Substring(6);
                		try
                		{
                			Directory.CreateDirectory(dirName);
                			Console.WriteLine("Directory {0} created successfully", dirName);
                		}
                		catch(Exception ex)
                		{
                			Console.WriteLine(ex.Message);
                		}
                		
                		break;
                	
                		
            		case "rm":
                		string directoryName = input.Substring(3);
                		
                		if(Directory.Exists(directoryName))
                		{
                			try
                			{
                				Directory.Delete(directoryName);
                				Console.WriteLine("Directory removed");
                			}
                			catch(Exception ex)
                			{
                				Console.WriteLine(ex.Message);
                			}
                		}
                		else
                		{
                			Console.WriteLine("Directory not found");
                		}
                		
                		break;
                	
                		
            		case "cat":
                		string filePath = input.Substring(4);

            			if (File.Exists(filePath))
            			{
                			try
                			{
                    			string[] lines = File.ReadAllLines(filePath);
                    			foreach (string line in lines)
                    			{
                        			Console.WriteLine(line);
                    			}
                			}
                			catch (Exception ex)
                			{
                    			Console.WriteLine(ex.Message);
                			}
            			}
            			else
            			{
            				Console.WriteLine("File not found");
            			}
                		
                		break;
                		
                		
            		case "echo":
                		string msg = input.Substring(5);
                		Console.WriteLine(msg);
                		break;
                		
            		case "clear":
                		Console.Clear();
                		break;
                		
            		case "history":
                		foreach(string cmd in commandsHistory)
                		{
                			Console.WriteLine(cmd);
                		}
                		break;
                	
                	
                	// Other commands
                	case "cal":
                		Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");
                		
                		DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            			int firstDayOfWeek = (int)firstDay.DayOfWeek;
            			
            			for (int i = 0; i < firstDayOfWeek; i++)
            			{
                			Console.Write("    ");
            			}
            			
            			for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            			{
                			Console.Write("{0, 4}", i);
                			if ((firstDayOfWeek + i) % 7 == 0)
                			{
                    			Console.WriteLine();
                			}
            			}
            			
                		break;
                		
                		
                	case "uptime":
                		PerformanceCounter uptime = new PerformanceCounter("System", "System Up Time");
                		uptime.NextValue();
                		
                		TimeSpan span = TimeSpan.FromSeconds(uptime.NextValue());
                		Console.WriteLine("{0}:{1}:{2}", span.Hours, span.Minutes, span.Seconds);
                		
                		break;
                		
                		
                	case "beep":
                		Console.Beep();
                		break;
                		
                		
                	case "shutdown":
                		Console.WriteLine("System will shut down in 10 seconds");
                		Process.Start("shutdown", "/s /t 10");
                		break;
                	
                		
            		default:
                		Console.WriteLine("Unknown command: {0}", input);
                		break;
        		}
        	}
    	}
	}
}
