using UnityEngine;

namespace PlatformerDemo
{
    public class PlayerActionInitializator : MonoBehaviour
    {
        [SerializeField] private InputKeyData _inputKeyData;
        [SerializeField] private InputEventDispatcher _inputEventDispatcher;

        public void AddButtonAction(KeyCode key, PlayerAction action)
        {
            _inputKeyData.Add(key, action);
            _inputEventDispatcher.AddAction(action);
        }
    }
}

