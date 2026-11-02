using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class WaypointContainer : MonoBehaviour
    {
        [SerializeField] private List<Waypoint> _waypoints;

        public List<Waypoint> Waypoints
            => new List<Waypoint>(_waypoints);

        private void Awake()
        {
            FillWaypoints();
        }

        private void FillWaypoints()
        {
            var waypoints = GetComponentsInChildren<Waypoint>();
            _waypoints = new List<Waypoint>(waypoints);
        }
    }
}

