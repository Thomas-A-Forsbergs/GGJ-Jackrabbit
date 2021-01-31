using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {
    private GameObject player;

    private void Start() {
        player = GameObject.FindWithTag("Player");
        var children = GetComponentsInChildren<Transform>();
        int randomIndex = UnityEngine.Random.Range(0, children.Length);
        player.transform.position = children[randomIndex].position;
    }
}
