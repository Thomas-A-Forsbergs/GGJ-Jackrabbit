using System.Collections.Generic;
using UnityEngine;

public class SpawnWinPoints : MonoBehaviour {
    private GameObject touchToWin;
    private List<Transform> spawnPoints;
    [SerializeField] private GameObject[] childrenObjectPrefabs;

    private void Start() {
        spawnPoints = new List<Transform>();
        var children = GetComponentsInChildren<Transform>();
        foreach(Transform child in children)
        {
            if (TryGetComponent(out TouchToWin win))
            {
                touchToWin = win.gameObject;
            }
            spawnPoints.Add(child.transform);
        }
        int randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Count);
        int randomChild = UnityEngine.Random.Range(0, childrenObjectPrefabs.Length);
        var instanceGameObject = Instantiate(childrenObjectPrefabs[randomChild], spawnPoints[randomSpawn]);
        instanceGameObject.transform.position = spawnPoints[randomSpawn].position;
        var tmpPosition = new Vector3(spawnPoints[randomSpawn].position.x, spawnPoints[randomSpawn].position.y +1, spawnPoints[randomSpawn].position.z);
        touchToWin.transform.position = tmpPosition;
    }
}
