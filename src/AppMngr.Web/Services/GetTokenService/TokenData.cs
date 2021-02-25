namespace AppMngr.Web
{
    public class TokenData
    {
        public string Token { get; set; }
        public string Name { get; set; }

        public TokenData(string token, string name)
        {
            Token = token;
            Name = name;
        }
    }
}