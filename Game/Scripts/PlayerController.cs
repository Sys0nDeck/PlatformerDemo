using PlatformerDemo.Movement;
using System;
using UnityEngine;

namespace PlatformerDemo
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private UserInputListener _input;
        [SerializeField] private InputEventDispatcher _actionManager;
        [SerializeField] private Hero _hero;
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
            _actionManager.Subscribe(PlayerAction.Jump, Jump);
        }

        private void OnDisable()
        {
            _actionManager.Unsubscribe(PlayerAction.Jump, Jump);
        }

        private void Jump()
        {
            _jumper.Jump(_hero.JumpPower);
        }

        private void Rotate(float axis)
        {
            _rotator.Rotate(axis);
        }

        private void Move(float axis)
        {
            var destination = transform.position + new Vector3(axis, 0f, 0f);
            _mover.Move(destination, _hero.Speed);
        }
    }
}

