using UnityEngine;

namespace PlatformerDemo
{
    public class Coin : MonoBehaviour
    {
        public void Disappear()
        {
            gameObject.SetActive(false);
        }
    }
}

