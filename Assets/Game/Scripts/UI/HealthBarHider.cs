using PlatformerDemo.Combat;
using UnityEngine;

public class HealthBarHider : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;
    [SerializeField] private DeadDetector _deadDetector;

    private void Start()
    {
        _healthView.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _deadDetector.Dead += HideHealthView;
    }

    private void OnDisable()
    {
        _deadDetector.Dead -= HideHealthView;
    }

    private void HideHealthView()
    {
        _healthView.gameObject.SetActive(false);
    }
}
