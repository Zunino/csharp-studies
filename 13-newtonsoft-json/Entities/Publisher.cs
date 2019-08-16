namespace _13_newtonsoft_json.Entities
{

    public enum Country
    {
        USA,
        BRAZIL,
        JAPAN
    }

    public class Publisher
    {
        public Publisher(string name, string nickname, Country country)
        {
            Name = name;
            Nickname = nickname;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Name} [{Nickname}, {Country}]";
        }

        public string Name { get; set; }
        public string Nickname { get; set; }
        public Country Country { get; set; }
    }

}

