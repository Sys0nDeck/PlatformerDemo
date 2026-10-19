using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    public Vector2 GetRandomPosition()
    {
        float x = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float y = Random.Range(_collider.bounds.min.y, _collider.bounds.max.y);

        return new Vector2(x, y);
    }
}
