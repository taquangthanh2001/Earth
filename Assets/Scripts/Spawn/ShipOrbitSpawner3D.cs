using UnityEngine;
using Sirenix.OdinInspector;

public class ShipOrbitSpawner3D : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform earthCenter;
    [SerializeField] private GameObject shipPrefab;

    [Header("Base Radius")]
    [SerializeField] private float orbitRadius = 7f;

    [Header("Main Orbit (Middle)")]
    [SerializeField] private float mainYOffset = 0f;
    [SerializeField] private float mainScale = 1f;
    [SerializeField] private int mainShipCount = 8;

    [Header("Top Orbit")]
    [SerializeField] private float topYOffset = 0.6f;
    [SerializeField] private float topScale = 0.85f;
    [SerializeField] private int topShipCount = 6;

    [Header("Bottom Orbit")]
    [SerializeField] private float bottomYOffset = -0.6f;
    [SerializeField] private float bottomScale = 0.85f;
    [SerializeField] private int bottomShipCount = 6;

    [Button("Spawn Main")]
    private void SpawnMain() => SpawnOrbit(mainYOffset, mainScale, mainShipCount);

    [Button("Spawn Top")]
    private void SpawnTop() => SpawnOrbit(topYOffset, topScale, topShipCount);

    [Button("Spawn Bottom")]
    private void SpawnBottom() => SpawnOrbit(bottomYOffset, bottomScale, bottomShipCount);

    private void SpawnOrbit(float yOffset, float radiusScale, int shipCount)
    {
        float radius = orbitRadius * radiusScale;

        for (int i = 0; i < shipCount; i++)
        {
            float angle = i * Mathf.PI * 2f / shipCount;

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            Vector3 spawnPos = earthCenter.position + new Vector3(x, yOffset, z);

            GameObject ship = Instantiate(shipPrefab, spawnPos, Quaternion.identity);
            ship.transform.LookAt(earthCenter.position);
        }
    }

    // 🔥 Gizmos preview cả 3 vòng
    private void OnDrawGizmos()
    {
        if (earthCenter == null) return;

        DrawOrbit(mainYOffset, mainScale, Color.cyan);
        DrawOrbit(topYOffset, topScale, Color.green);
        DrawOrbit(bottomYOffset, bottomScale, Color.red);
    }

    private void DrawOrbit(float yOffset, float scale, Color color)
    {
        Gizmos.color = color;

        int segments = 100;
        Vector3 prevPoint = Vector3.zero;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * Mathf.PI * 2f / segments;

            float x = Mathf.Cos(angle);
            float z = Mathf.Sin(angle);

            Vector3 dir = new Vector3(
                x * scale,
                yOffset,
                z * scale
            ).normalized;

            Vector3 point = earthCenter.position + dir * orbitRadius;

            if (i > 0)
                Gizmos.DrawLine(prevPoint, point);

            prevPoint = point;
        }
    }
}