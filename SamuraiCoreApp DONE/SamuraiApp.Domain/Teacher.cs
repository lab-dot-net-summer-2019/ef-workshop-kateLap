using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Samurai> Samurais { get; set; }
    }
}
