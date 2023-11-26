namespace BankingApi.Identity
{
    public class UserDb
    {
       public static List<User> users = new ()
       {
            new User()
            {
                FirstName = "Obinna Nick",
                Email = "johndro@gmail.com",
                Username = "Rankshoe",
                Password = "ranks3674"
            },
            new User()
            {
                FirstName = "bart Doe",
                Email = "philro@gmail.com",
                Username = "phili",
                Password = "Philf74"
            },
       };
    }
}