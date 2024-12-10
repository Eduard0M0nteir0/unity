using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    public GameObject groundTile;
    // public GameObject treeTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile() {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // public void SpawnTree() {
    //     GameObject temp = Instantiate(treeTile, nextSpawnPoint, Quaternion.identity);
    //     nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    // }

    private void Start() {
        for(int i=0; i<5; i++)
        {
            SpawnTile();
            // SpawnTree();
        }
    }
}
