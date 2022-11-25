using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Transform enemiesParent;

    [Header(" Settings ")]
    [SerializeField] int amount;
    [SerializeField] float radius;
    [SerializeField] float goldenAngle;

    private void Start()
    {
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        for(int i = 0; i < amount; i++)
        {
            Vector3 enemyLocalPosition = GetRunnerLocalPosition(i);

            Vector3 enemyWorldPosition = transform.TransformPoint(enemyLocalPosition);

            Instantiate(enemyPrefab, enemyWorldPosition, Quaternion.identity, enemiesParent);
        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * goldenAngle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * goldenAngle);

        return new Vector3(x, 0, z);
    }
}
