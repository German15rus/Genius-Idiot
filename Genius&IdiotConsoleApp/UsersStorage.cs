using Newtonsoft.Json;
namespace Genius___Idiot

{
    public class UsersStorage
    {
        private string path = "records.json";
        List<User> users = new List<User>();

        public void Add(User user)
        {
            List<User> users = GetAll();

            users.Add(user);

            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, jsonString);
        }

        public List<User> GetAll()
        {
            if (!File.Exists(path))
            {
                return new List<User>();
            }

            string jsonString = File.ReadAllText(path);
            if (jsonString == null)
            {
                return new List<User>();
            }
            else
            {
                users = JsonConvert.DeserializeObject<List<User>>(jsonString);
                return users;
            }
        }
    }
}
