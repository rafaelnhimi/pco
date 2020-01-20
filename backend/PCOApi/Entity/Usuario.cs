namespace PCOApi.Entity
{
    public class Usuario
    {
        public Usuario(string login)
        {
            Login = login;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
