using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {
    private GameObject player;
    private List<Transform> spawnPoints;

    private void Start() {
        spawnPoints = new List<Transform>();
        player = GameObject.FindWithTag("Player");
        var children = GetComponentInChildren<Transform>();
        foreach(Transform child in children) {
            spawnPoints.Add(child.transform);
        }
        int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Count-1);
        player.transform.position = spawnPoints[randomIndex].position;
    }
}
