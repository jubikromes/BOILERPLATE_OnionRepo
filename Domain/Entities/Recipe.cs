using Shared;

namespace Domain.Entities
{
    public class Recipe : EntityBase
    {
        public string? Name { get;  set; }

        public string? Description { get;  set; }
    }
}
