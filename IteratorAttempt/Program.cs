using System;
using System.Collections.Generic;

namespace IteratorAttempt
{
	public class Program
	{
		private static readonly int  INCREMENT_SIZE = 30;

		static int Main(string[] args)
		{
			while (true)
			{
				Console.Write("Enter the last completed row number, out of 100 (0 ~ 99): ");
				var input = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("Exiting program...");
					return 0;
				}
				
				var number = int.Parse(input);


				if (number >= 100 || number < 0)
				{
					Console.WriteLine("number out of range, exiting program.");
					Console.ReadKey();
				}
				ProcessItems(number);
				Console.WriteLine("---------------------------------------------------------------");
			}
		}

		private static void ProcessItems(int lastCompletedRowNumber)
		{
			var iterator = new PersonIterator(lastCompletedRowNumber);
			var rowsProcessedCount = 0;
			var progressLog = new List<int>();

			foreach (var person in iterator)
			{
				// Do something with item
				Console.Write($"({person.RowNumber}){person.FirstName}");
				rowsProcessedCount++;

				// Save progress if an increment is reached.
				if (iterator.RowsCompletedCounter % INCREMENT_SIZE == 0)
				{
					progressLog.Add(person.RowNumber);

				}
			}
			Console.WriteLine("Progress saved: " + string.Join(", ", progressLog));
			Console.WriteLine($"\nRows processed {rowsProcessedCount}");
		}
	}
}
