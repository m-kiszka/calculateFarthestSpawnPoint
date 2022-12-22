using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farthestSpawnPointCalculator : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] players;

    [Header("Calculate in axis:")]
    public bool x = false;
    public bool y = false;
    public bool z = false;

    [Header("")]
    public bool calculate = false;

    [Header("Results:")]
    public GameObject farthestSpawnPoint;
    public float farthestDistance;

    public GameObject calculateFarthestSpawnPoint()
    {
        float highestDistance = 0f;
        float currentDistance;
        GameObject returnSpawnPoint = null;

        foreach(Transform spawnPoint in spawnPoints)
        {
            foreach(Transform player in players)
            {
                if(x && y)
                {
                    float xDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.x) - Mathf.Abs(player.position.x));
                    float yDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.y) - Mathf.Abs(player.position.y));
                    currentDistance = Mathf.Abs(xDistance - yDistance);
                }
                else if(x && z)
                {
                    float xDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.x) - Mathf.Abs(player.position.x));
                    float zDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.z) - Mathf.Abs(player.position.z));
                    currentDistance = Mathf.Abs(xDistance - zDistance);
                }
                else if(y && z)
                {
                    float yDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.y) - Mathf.Abs(player.position.y));
                    float zDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.z) - Mathf.Abs(player.position.z));
                    currentDistance = Mathf.Abs(zDistance - yDistance);
                }
                else if(x)
                {
                    currentDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.x) - Mathf.Abs(player.position.x));
                }
                else if(y)
                {
                    currentDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.y) - Mathf.Abs(player.position.y));
                }
                else if(z)
                {
                    currentDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.z) - Mathf.Abs(player.position.z));
                }
                else
                {
                    currentDistance = Mathf.Abs(Mathf.Abs(spawnPoint.position.magnitude) - Mathf.Abs(player.position.magnitude));
                }

                if(currentDistance > highestDistance)
                {
                    highestDistance = currentDistance;
                    returnSpawnPoint = spawnPoint.gameObject;
                }
            }
        }

        farthestDistance = highestDistance;
        return returnSpawnPoint;
    }

    void OnValidate()
    {
        if (calculate)
        {
            farthestSpawnPoint = calculateFarthestSpawnPoint();

            calculate = false;
        }
    }
}
