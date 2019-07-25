namespace SamuraiApp.Domain
{
    public class SecretIdentity
    {
        public int Id { get; set; }

        public string RealName { get; set; }

        public virtual Samurai Samurai { get; set; }
    }
}
