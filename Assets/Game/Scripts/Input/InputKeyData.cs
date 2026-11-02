using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class InputKeyData : MonoBehaviour
    {
        private Dictionary<KeyCode, PlayerAction> _keyToAction = new Dictionary<KeyCode, PlayerAction>();

        public void Add(KeyCode key, PlayerAction action)
            => _keyToAction.Add(key, action);

        public  List<KeyCode> GetKeys
            => new List<KeyCode>(_keyToAction.Keys);

        public  PlayerAction GetAction(KeyCode key)
            => _keyToAction[key];
    }
}

