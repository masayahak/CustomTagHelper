namespace CustomTagHelper.Pages
{
    public interface IUser
    {
        string Name { get; }
    }
    public class User : IUser
    {
        public string Name { get; set; }

        public User()
        {
            Name = "test1";
        }
    }
}
