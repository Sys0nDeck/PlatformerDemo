using System.Collections;
using UnityEngine;

namespace PlatformerDemo
{
    public class TargetSwitcher : MonoBehaviour
    {
        [SerializeField] private WaypointRouter _waypointRouter;
        [SerializeField] private PlayerDetector _playerDetector;
        [SerializeField] private float _timeDelay = 5;

        private Coroutine _delayCoroutine;
        private bool _isChasing = false;

        public Transform CurrentTarget { get; private set; }

        private void OnEnable()
        {
            _playerDetector.Spotted += StartChasing;
            _playerDetector.Losted += LostChasingTarget;
            _waypointRouter.WaypointChanged += SetPatrolMode;
        }

        private void OnDisable()
        {
            _playerDetector.Spotted -= StartChasing;
            _playerDetector.Losted -= LostChasingTarget;
            _waypointRouter.WaypointChanged -= SetPatrolMode;

            if (_delayCoroutine != null)
                StopCoroutine(_delayCoroutine);
        }

        private void Start()
        {
            _waypointRouter.Launch();
            SetPatrolMode();
        }

        private void StartChasing(Transform target)
        {
            if (_delayCoroutine != null)
                StopCoroutine(_delayCoroutine);

            _isChasing = true;
            CurrentTarget = target;
        }

        private void SetPatrolMode()
        {
            if (_isChasing == false)
            {
                CurrentTarget = _waypointRouter.CurrentWaypoint.transform;
            }
        }

        private void LostChasingTarget()
        {
            if (_delayCoroutine != null)
                StopCoroutine( _delayCoroutine);

            _delayCoroutine = StartCoroutine(DelayAfterLosted(_timeDelay));
        }

        private IEnumerator DelayAfterLosted(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            _isChasing = false;
            SetPatrolMode();
        }
    }
}

