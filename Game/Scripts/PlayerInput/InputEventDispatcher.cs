using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class InputEventDispatcher : MonoBehaviour
    {
        private Dictionary<PlayerAction, Action> _buttonActions = new Dictionary<PlayerAction, Action>
        {
            { PlayerAction.Jump, null }
        };

        public void Subscribe(PlayerAction playerAction, Action callback)
        {
            if (_buttonActions.ContainsKey(playerAction))
                _buttonActions[playerAction] += callback;
            else
                Debug.Log($"Action {playerAction} not exist in dict.");
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

