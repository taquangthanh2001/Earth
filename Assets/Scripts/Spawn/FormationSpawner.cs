using Sirenix.OdinInspector;
using UnityEngine;

public class FormationSpawner : MonoBehaviour
{
    public FormationData formationData;

    public Transform earth;

    public float spawnRadius = 40f;
    public float cellSize = 1.5f;

    public GameObject normalPrefab;
    public GameObject elitePrefab;
    public GameObject bossPrefab;
    public GameObject superBotPrefab;

    [Button]
    public void SpawnFormation()
    {
        // chọn vị trí random quanh earth
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        Vector3 dir = new Vector3(
            Mathf.Cos(angle),
            0,
            Mathf.Sin(angle)
        );

        Vector3 spawnCenter = earth.position + dir * spawnRadius;

        //--------------------------------
        // tạo formation leader
        //--------------------------------
        GameObject formationGO = new GameObject("EnemyFormation");

        formationGO.transform.position = spawnCenter;

        // xoay formation hướng vào earth
        Vector3 lookDir = (earth.position - spawnCenter).normalized;

        formationGO.transform.rotation =
            Quaternion.LookRotation(lookDir);

        //--------------------------------
        // formation controller
        //--------------------------------
        FormationController controller =
            formationGO.AddComponent<FormationController>();

        controller.earth = earth;

        //--------------------------------
        // spawn grid
        //--------------------------------
        int width = formationData.width;
        int height = formationData.height;

        float centerOffsetX = (width - 1) / 2f;
        float centerOffsetY = (height - 1) / 2f;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                EnemyType type = formationData.Get(x, y);

                if (type == EnemyType.None)
                    continue;

                GameObject prefab = GetPrefab(type);

                if (prefab == null)
                    continue;

                //--------------------------------
                // offset trong formation
                //--------------------------------
                Vector3 localOffset = new Vector3(
                    (x - centerOffsetX) * cellSize,
                    0,
                    (y - centerOffsetY) * cellSize
                );

                //--------------------------------
                // convert local -> world
                //--------------------------------
                Vector3 spawnPos =
                    formationGO.transform.TransformPoint(localOffset);

                //--------------------------------
                // spawn enemy từ pool
                //--------------------------------
                GameObject enemy =
                    PoolManager.Instance.Spawn(
                        prefab,
                        spawnPos,
                        formationGO.transform.rotation
                    );

                //--------------------------------
                // parent vào formation
                //--------------------------------
                enemy.transform.SetParent(formationGO.transform);

                //--------------------------------
                // enemy nhìn vào earth
                //--------------------------------
                enemy.transform.LookAt(earth);

                //--------------------------------
                // formation member
                //--------------------------------
                EnemyFormationMember member =
                    enemy.GetComponent<EnemyFormationMember>();

                if (member != null)
                {
                    member.Init(
                        formationGO.transform,
                        localOffset
                    );
                }

                //--------------------------------
                // enemy attack
                //--------------------------------
                EnemyAttack attack =
                    enemy.GetComponent<EnemyAttack>();

                if (attack != null)
                {
                    attack.Init(earth);
                }
            }
        }
    }

    GameObject GetPrefab(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Normal:
                return normalPrefab;

            case EnemyType.Elite:
                return elitePrefab;

            case EnemyType.Boss:
                return bossPrefab;

            case EnemyType.SuperBot:
                return superBotPrefab;
        }

        return null;
    }
}