using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

    // To increment ingame
    private float spawnInterval = 1.5f;
    private int numOfObjectsToSpawn = 1;
    private int intervalBetweenDesignedSituations = 10;

    private float speed = 3;

    private List<GameObject> obstacles;
    private List<GameObject> handDesignedSituations;

    private bool bSpawn = true;

    void Initialize()
    {
        // List the Obstacles
        obstacles = new List<GameObject>();
        GameObject[] obsts = Resources.LoadAll<GameObject>("Obstacles");
        for (int i = 0; i < obsts.Length; i++)
        {
            obstacles.Add(obsts[i]);
        }

        // List the Hand designed situations
        handDesignedSituations = new List<GameObject>();
        GameObject[] handDes = Resources.LoadAll<GameObject>("PrefabsSituationsObstacles");
        for (int i = 0; i < handDes.Length; i++)
        {
            handDesignedSituations.Add(handDes[i]);
        }

    }

	void Start ()
    {
        Initialize();
        StartCoroutine("Spawn");
        StartCoroutine("SuperSale");
    }

    IEnumerator SuperSale()
    {
        Debug.Log("Niveau 0");

        yield return new WaitForSeconds(20);
        ChangeSettings(3, 1.2f, 1, 9);
        Debug.Log("Niveau 1");

        yield return new WaitForSeconds(20);
        ChangeSettings(4, 1f, 2, 8);
        Debug.Log("Niveau 2");

        yield return new WaitForSeconds(10);
        ChangeSettings(5, 0.8f, 3, 7);
        Debug.Log("Niveau 3");

        yield return new WaitForSeconds(10);
        ChangeSettings(6, 0.6f, 4, 6);
        Debug.Log("Niveau 4");

        yield return new WaitForSeconds(10);
        Debug.Log("BRAVO le veau");

        yield return new WaitForEndOfFrame();
    }


    void ChangeSettings(int speed, float spawnInterval, int numOfObjects, int intervalBetweenSituations)
    {
        this.spawnInterval = spawnInterval;
        this.numOfObjectsToSpawn = numOfObjects;
        this.intervalBetweenDesignedSituations = intervalBetweenSituations;

        this.speed = speed;
        

        // Update already spawned Obstacles
        Obstacle[] obsList = GameObject.FindObjectsOfType<Obstacle>();
        for (int i = 0; i < obsList.Length; i++)
        {
            obsList[i].speed = speed;
        }
    }

    IEnumerator Spawn()
    {
        int interval = 0;
        while (bSpawn)
        {
            yield return new WaitForSeconds(spawnInterval);
            interval++;
            if (interval == intervalBetweenDesignedSituations)
            {
                interval = 0;

				//float x = Random.Range(0, 6); float y = Random.Range(0, 6);
                //x /= 8; y /= 8;
                int handDesignedSitu = Random.Range(0, handDesignedSituations.Count);

                Vector3 spawnPos = transform.position;
                GameObject instantiatedObstacle = Instantiate(handDesignedSituations[handDesignedSitu], spawnPos, Quaternion.identity) as GameObject;
                instantiatedObstacle.GetComponent<Obstacle>().speed = speed;
            }
            else
            {
                for (int i = 0; i < Random.Range(numOfObjectsToSpawn, numOfObjectsToSpawn*2); i++)
                {
					float x = Random.Range(0, 6); float y = Random.Range(0, 6);
                    x /= 4; y /= 4;
                    int obstNum = Random.Range(0, obstacles.Count);

                    Vector3 spawnPos = transform.position + new Vector3(0, y-.5f, x - 0.5f);
                    GameObject instantiatedObstacle = Instantiate(obstacles[obstNum], spawnPos, Quaternion.identity) as GameObject;
                    instantiatedObstacle.GetComponent<Obstacle>().speed = speed;
                }
            }   
            yield return new WaitForEndOfFrame();
        }
    }
}
