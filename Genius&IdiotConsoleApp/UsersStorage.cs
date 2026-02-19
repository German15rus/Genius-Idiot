namespace Genius___Idiot
{
	public class UsersStorage
    {
		private string resultPath = "..\\..\\..\\гений идиот.txt";
		public void Finish(User user)
		{
			string results = ($"{user.Name}#{user.CorrectAnswers}#{user.Diagnos}");
			File.AppendAllText(resultPath, results + Environment.NewLine);
		}
		public List<User> ReturnList()
		{
			List<User> users = new List<User>();
			User user = new User();
			string[] s = File.ReadAllLines(resultPath);
			for (int i = 0; i < s.Length; i++)
			{
				string line = s[i];
				string[] data = line.Split(' ');
				user.Name = data[0];
				user.CorrectAnswers = int.Parse(data[1]);
				user.Diagnos = data[2];
				users.Add(user);
			}
			return users;
		}
	}
}
