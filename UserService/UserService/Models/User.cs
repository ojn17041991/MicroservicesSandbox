namespace UserService.Models
{
    public class User
    {
        public int Id { get; set; } = default(int);

        // OJN: attribute to limit character size???
        public string Name { get; set; } = string.Empty;
    }
}
