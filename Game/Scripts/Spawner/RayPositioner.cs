using PlatformerDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPositioner : MonoBehaviour
{
    [SerializeField] private SpawnZone _zone;

    private float _rayDistance = 50f;
    private float _heightOffset = 0.7f;

    public Vector3 GetRandomSpawnPosition()
    {
        Vector3 rayPosition = _zone.GetRandomPosition();
        var points = new List<Vector2>();

        var hits = Physics2D.RaycastAll(rayPosition, Vector2.down, _rayDistance);

        foreach (var hit in hits)
        {
            if (hit.collider.TryGetComponent<Ground>(out _))
            {
                points.Add(hit.point);
            }
        }

        var randomPoint = points[Random.Range(0, points.Count)];

        return new Vector3(randomPoint.x, randomPoint.y + _heightOffset, 0f);
    }


}
