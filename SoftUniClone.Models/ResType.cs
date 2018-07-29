namespace SoftUniClone.Models
{
    using System.Collections.Generic;

    public class ResType
    {
        public ResType()
        {
            this.Resources= new List<Resource>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}
