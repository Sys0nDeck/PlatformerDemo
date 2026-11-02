using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class SpawnPointContainer : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _points;

        public List<SpawnPoint> Points
            => new List<SpawnPoint>(_points);

        private void Awake()
        {
            FillPoints();
        }

        private void FillPoints()
        {
            var points = GetComponentsInChildren<SpawnPoint>();
            _points = new List<SpawnPoint>(points);
        }
    }
}

