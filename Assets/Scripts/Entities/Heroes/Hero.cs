namespace Entities.Heroes
{
    public class Hero : Entity 
    {
        public int Hp { get; set; }
        
        public Hero(int id) : base(id)
        {
        }
    }
}