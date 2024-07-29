namespace IBDApp.Models
{
    public class ProfileModel
    { 
        private readonly int _id;
        private readonly string _name;
        private string _description;
        private readonly int _age;
        private string ?_fullName;

        public ProfileModel(int id, string name, string description, int age)
        {
            _id = id;
            _name = name;
            _description = description;
            _age = age;
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } set { _description = value; } }
        public int Age { get { return _age; } }
        public string FullName { get { return _fullName ?? ""; } set { _fullName = value; } }
    }
}
