using System.Runtime.Intrinsics.X86;

namespace Genius___Idiot
{
	public class User
	{
		public string Name;
		public string Diagnos;
		public int CorrectAnswers;
		

		public User UserName(User user)
		{
			user.Name = Console.ReadLine()!.Trim();
			user.Name = char.ToUpper(user.Name[0]) + user.Name.Substring(1);
			return user;
		}
    }
}
