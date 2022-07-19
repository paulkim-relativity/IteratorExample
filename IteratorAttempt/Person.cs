using CsvHelper.Configuration.Attributes;

namespace IteratorAttempt
{
	public class Person
	{
		[Name("rownumber")]
		public int RowNumber { get; set; }

		[Name("firstname")]
		public string FirstName { get; set; }

		[Name("lastname")]
		public string LastName { get; set; }

		[Name("email")]
		public string Email { get; set; }
	}
}
