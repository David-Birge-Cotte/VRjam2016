using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    public Obstacle currentObstacle;

	void Start ()
    {
	
	}	

	void Update ()
    {
        if (currentObstacle.transform.position.x < 1 && currentObstacle.transform.position.x > -1)
        {
            bool bPasseObstacle = currentObstacle.TestAllTriggers();
            Debug.Log("Yolo : " + bPasseObstacle);
        }
            

    }
}
