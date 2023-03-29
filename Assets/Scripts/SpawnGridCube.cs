using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGridCube : MonoBehaviour
{
    [Header("Configurations")]
    public int gridX;
    public int gridZ;

    [Header("Floor")]
    [SerializeField] GameObject[] blockFloorToPickFrom;

    [Header("Environments")]
    [SerializeField] GameObject[] environmentsToPickFrom;

    void PickAndSpawnFloor(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, blockFloorToPickFrom.Length);
        GameObject clone = Instantiate(blockFloorToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
