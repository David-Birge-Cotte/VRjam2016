using UnityEngine;
using System.Collections;

public class TriggerForObstacle : MonoBehaviour {

    public bool bIsTriggered;

    void OnTriggerEnter()
    {
        bIsTriggered = true;
    }

    void OnTriggerExit()
    {
        bIsTriggered = false;
    }
}
