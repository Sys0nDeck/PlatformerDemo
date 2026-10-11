using UnityEngine;

namespace PlatformerDemo
{
    public class UserInputListener : MonoBehaviour
    {
        [SerializeField] private InputEventDispatcher _actionManager;

        private void Update()
        {
            ListenPressingButton();
        }

        public float GetXAxis()
            => Input.GetAxisRaw(InputAxisData.Horizontal);

        private void ListenPressingButton()
        {
            if (Input.anyKeyDown)
                foreach (var key in InputKeyData.GetKeys)
                    if (Input.GetKeyDown(key))
                        _actionManager.InvokeAction(InputKeyData.GetAction(key));
        }
    }
}