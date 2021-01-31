using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject player;

    private void Start()
    {
        player = Instantiate(playerPrefab);
        var children = GetComponentsInChildren<Transform>();
        int randomIndex = UnityEngine.Random.Range(0, children.Length);
        player.transform.position = children[randomIndex].position;
    }
}
