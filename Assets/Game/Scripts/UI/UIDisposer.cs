using UnityEngine;

public class UIDisposer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private RectTransform _uiElement;

    private void Start()
    {
        ToCenterElement();
    }

    private void LateUpdate()
    {
        Dispose();
    }

    private void Dispose()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(_target.position);
        _uiElement.anchoredPosition3D = screenPosition;
    }

    private void ToCenterElement()
    {
        _uiElement.pivot = new Vector2(0.5f, 0.5f);
    }
}
