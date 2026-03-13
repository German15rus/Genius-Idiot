using Newtonsoft.Json;
namespace Genius___Idiot

{
    public class UsersStorage
    {
        private string path = "records.json";
        List<User1> users = new List<User1>();

        public void Add(User1 user)
        {
            List<User1> users = GetAll();

            users.Add(user);

            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, jsonString);
        }

        public List<User1> GetAll()
        {
            if (!File.Exists(path))
            {
                return new List<User1>();
            }

            string jsonString = File.ReadAllText(path);
            if (jsonString == null)
            {
                return new List<User1>();
            }
            else
            {
                users = JsonConvert.DeserializeObject<List<User1>>(jsonString);
                return users;
            }
        }
    }
}
