using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class InputEventDispatcher : MonoBehaviour
    {
        private Dictionary<PlayerAction, Action> _buttonActions = new Dictionary<PlayerAction, Action>();

        public void AddAction(PlayerAction action)
        {
            _buttonActions.Add(action, null);
        }

        public void Subscribe(PlayerAction playerAction, Action callback)
        {
            if (_buttonActions.ContainsKey(playerAction))
                _buttonActions[playerAction] += callback;
            else
                Debug.LogError($"Action {playerAction} not exist in dict.");
        }

        public void Unsubscribe(PlayerAction playerAction, Action callback)
        {
            if (_buttonActions.ContainsKey(playerAction))
                _buttonActions[playerAction] -= callback;
        }

        public void InvokeAction(PlayerAction action)
            => _buttonActions[action]?.Invoke();
    }
}

