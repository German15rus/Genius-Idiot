namespace Genius___Idiot
{
    public class UsersStorage
    {
        private string resultPath = "..\\..\\..\\гений идиот.txt";
        public void Finish(User user)
        {
            string result = ($"{user.Name}#{user.CorrectAnswers}#{user.Diagnos}");
            File.AppendAllText(resultPath, result + Environment.NewLine);
        }
        public List<User> ReturnList()
        {
            List<User> users = new List<User>();

            foreach (string line in File.ReadAllLines(resultPath))
            {
                string[] data = line.Split('#');
                User user = new User();
                user.Name = data[0];
                user.CorrectAnswers = int.Parse(data[1]);
                user.Diagnos = data[2];
                users.Add(user);
            }
            return users;
        }

        public bool CheckFile()
        {
            return File.Exists(resultPath);
        }
    }
}
