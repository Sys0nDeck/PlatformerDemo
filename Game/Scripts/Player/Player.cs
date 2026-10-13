using PlatformerDemo.Movement;
using UnityEngine;

namespace PlatformerDemo
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private UserInputListener _input;
        [SerializeField] private InputEventDispatcher _inputEventDispatcher;
        [SerializeField] private Mover _mover;
        [SerializeField] private Rotator _rotator;
        [SerializeField] private Jumper _jumper;

        private void Update()
        {
            var axis = _input.GetXAxis();
            Move(axis);
            Rotate(axis);
        }

        private void OnEnable()
        {
            _inputEventDispatcher.Subscribe(PlayerAction.Jump, Jump);
        }

        private void OnDisable()
        {
            _inputEventDispatcher.Unsubscribe(PlayerAction.Jump, Jump);
        }

        private void Jump()
        {
            _jumper.Jump();
        }

        private void Rotate(float axis)
        {
            _rotator.Rotate(axis);
        }

        private void Move(float axis)
        {
            var destination = transform.position + new Vector3(axis, 0f, 0f);
            _mover.Move(destination);
        }
    }
}

