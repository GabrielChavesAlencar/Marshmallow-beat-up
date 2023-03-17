using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HeroDetector : MonoBehaviour {

    public bool heroIsNearby;
    public GameObject player;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hero"){
            heroIsNearby = true;
            player = collider.gameObject;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Hero"){
            heroIsNearby = false;
            player = collider.gameObject;
        }
    }
}
