namespace _13_newtonsoft_json.Entities
{

    public class Game
    {
        public Game(string title, int year, Publisher publisher)
        {
            Title = title;
            Year = year;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return $"{Title} [{Publisher.Name}, {Year}]";
        }

        public string Title { get; }
        public int Year { get; }
        public Publisher Publisher { get; }
    }

}

