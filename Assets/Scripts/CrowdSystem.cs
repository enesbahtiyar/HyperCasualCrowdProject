using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform runnersParent;

    [Header(" Settings ")]
    [SerializeField] float radius;
    [SerializeField] float goldenAngle;


    void Update()
    {
        PlaceRunners();
    }

    private void PlaceRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * goldenAngle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * goldenAngle);

        return new Vector3(x, 0, z);
    }
}
