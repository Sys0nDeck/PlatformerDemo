using UnityEngine;

namespace PlatformerDemo
{
    public class UserInputListener : MonoBehaviour
    {
        [SerializeField] private PlayerActionInitializator _playerActionInitializator;
        [SerializeField] private InputEventDispatcher _inputActionDispatcher;
        [SerializeField] private InputKeyData _inputKeyData;
        [SerializeField] private Player _player;

        private void Awake()
        {
            InitKeyActions();
            _player.gameObject.SetActive(true);
        }

        private void Update()
        {
            ListenPressingButton();
        }

        public float GetXAxis()
            => Input.GetAxisRaw(InputAxisData.Horizontal);

        private void ListenPressingButton()
        {
            if (Input.anyKeyDown)
                foreach (var key in _inputKeyData.GetKeys)
                    if (Input.GetKeyDown(key))
                        _inputActionDispatcher.InvokeAction(_inputKeyData.GetAction(key));
        }

        private void InitKeyActions()
        {
            _playerActionInitializator.AddButtonAction(KeyCode.Space, PlayerAction.Jump);
            _playerActionInitializator.AddButtonAction(KeyCode.K, PlayerAction.Attack);
        }
    }
}