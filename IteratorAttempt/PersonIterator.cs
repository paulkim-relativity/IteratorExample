using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace IteratorAttempt
{
	public class PersonIterator : IEnumerable<Person>
	{
		public int RowsCompletedCounter { get; private set; }
		private readonly int _startingPoint;

		public PersonIterator(int startingPoint)
		{
			this._startingPoint = startingPoint;
		}

		public IEnumerator<Person> GetEnumerator()
		{
			using (var reader = new StreamReader("SampleData/people.csv"))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			using(var recordEnumerator = csv.GetRecords<Person>().GetEnumerator())
			{
				if (this._startingPoint > 0)
				{
					int skipCount = _startingPoint;
					while (skipCount > 0)
					{
						recordEnumerator.MoveNext();
						skipCount--;
					}
				}

				while (recordEnumerator.MoveNext())
				{
					if (recordEnumerator.Current == null) 
						continue;

					RowsCompletedCounter++;
					yield return recordEnumerator.Current;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}