using EcmaScript.NET;

using System;
using System.IO;

using Yahoo.Yui.Compressor;


namespace YIUCompressTest
{
    class Program
	{

		static void Main(string[] args)
		{
			if (args.Length ==0)
			{
				Console.WriteLine("Run with full path to js file. Press Enter to exit");
                Console.ReadLine();
                Environment.Exit(0);
            }
			var jsCompr = new JavaScriptCompressor();
			var js = File.ReadAllText(args[0]);
            try
            {
                jsCompr.Compress(js);
                Console.WriteLine("Your script is fine!");
                Console.ReadLine();
            }
            catch (EcmaScriptRuntimeException e)
            {
                Console.WriteLine($"Error on line {e.LineNumber}");
                Console.WriteLine("Wrong lne text:");
                Console.WriteLine($"{e.LineSource}");
                Console.WriteLine("");
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something really bad happened. Here it is:");
                Console.WriteLine(e);
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
		}
	}
}
