using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _prefab;
        [SerializeField] private SpawnPointContainer _spawnPoints;

        private void Start()
        {
            ReplaceCoins();
        }

        private void ReplaceCoins()
        {
            foreach (var point in _spawnPoints.Points)
                Spawn(point.transform);
        }

        private void Spawn(Transform point)
        {
            Instantiate(_prefab, point);
        }
    }
}

