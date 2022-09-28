namespace meet_room.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Homework> Homeworks { get; set; }

        public string FullName => UserName;
    }

    public class Homework
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
