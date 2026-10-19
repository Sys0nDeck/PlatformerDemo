using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerDemo
{
    public class WaypointRouter : MonoBehaviour
    {
        [SerializeField] private WaypointContainer _waypointContainer;
        [SerializeField] private DistanceDetector _distanceDetector;

        private IEnumerator<Waypoint> _waypointEnumerator;

        public event Action WaypointChanged;

        public Waypoint CurrentWaypoint
            => _waypointEnumerator.Current;

        private void Awake()
        {
            _waypointEnumerator = EnumerateWaypoints();
        }

        private void OnEnable()
        {
            _distanceDetector.TargetReached += HandleReceivedPoint;
        }

        private void OnDisable()
        {
            _distanceDetector.TargetReached += HandleReceivedPoint;
        }

        public void Launch()
        {
            SendWaypoint(GetNextWaypoint());
        }

        private void HandleReceivedPoint()
        {
            SendWaypoint(GetNextWaypoint());
            WaypointChanged?.Invoke();
        }

        private void SendWaypoint(Waypoint waypoint)
        {
            _distanceDetector.SetTarget(waypoint.transform.position);
        }

        private Waypoint GetNextWaypoint()
        {
            _waypointEnumerator.MoveNext();
            return _waypointEnumerator.Current;
        }

        private IEnumerator<Waypoint> EnumerateWaypoints()
        {
            var waypoints = _waypointContainer.Waypoints;
            bool isWork = true;

            while (isWork)
            {
                foreach (var waypoint in waypoints)
                    yield return waypoint;

                waypoints.Reverse();
            }
        }
    }
}

