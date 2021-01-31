using System.Collections.Generic;
using UnityEngine;

public class SpawnWinPoints : MonoBehaviour {
    private GameObject touchToWin;
    private List<Transform> spawnPoints;
    [SerializeField] private GameObject[] childrenObjectPrefabs;

    private void Start() {
        spawnPoints = new List<Transform>();
        touchToWin = GameObject.FindWithTag("WinPointBox");
        var children = GetComponentInChildren<Transform>();
        foreach(Transform child in children)
        {
            if (child.GetComponent<TouchToWin>()) return;
            spawnPoints.Add(child.transform);
            int RandomIndex = UnityEngine.Random.Range(0, childrenObjectPrefabs.Length);
            Instantiate(childrenObjectPrefabs[RandomIndex], child.transform);
        }
        int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        var tmpPosition = new Vector3(spawnPoints[randomIndex].position.x, spawnPoints[randomIndex].position.y +1, spawnPoints[randomIndex].position.z);
        touchToWin.transform.position = tmpPosition;
    }
}
