using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public static class InputKeyData
    {
        private static Dictionary<KeyCode, PlayerAction> s_keyToAction = new Dictionary<KeyCode, PlayerAction>
    {
        { KeyCode.Space, PlayerAction.Jump }
    };

        public static List<KeyCode> GetKeys
            => new List<KeyCode>(s_keyToAction.Keys);

        public static PlayerAction GetAction(KeyCode key)
            => s_keyToAction[key];
    }
}

