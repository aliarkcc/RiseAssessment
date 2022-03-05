using Core.Entities;

namespace Entities.Dto
{
    public class ContactLocationDescDto:IDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
