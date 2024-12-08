using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour {
    GroundSpawner groundSpawner;
    private float startTime; 
    private float runTime;
    void Start() {
        startTime = Time.time;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();

        runTime = Time.time - startTime;
        // if (runTime > 2f) {
        //     // groundSpawner.SpawnTree();
        //     Destroy(gameObject, 2);
        // }
        
        Destroy(gameObject, 2);
    }
}
