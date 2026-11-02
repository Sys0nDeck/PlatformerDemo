using UnityEngine;

namespace PlatformerDemo 
{
    public interface IPickable
    {
        public void UseItem(Collider2D owner);
    }
}


