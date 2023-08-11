using Zenject;

namespace Entities.Enemies
{
    public class Enemy : Entity
    {
        public int Attack { get; set; }
        
        public Enemy(int id) : base(id)
        {
        }
    }
}