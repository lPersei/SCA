using UnityEngine;

namespace Entities
{
    public abstract class Entity
    {
        public int Id { get; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        protected Entity(int id)
        {
            Id = id;
        }
    }
}