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
            if (child.TryGetComponent(out TouchToWin win))
            {
                touchToWin = win.gameObject;
            }
            else
            {
                spawnPoints.Add(child.transform);    
            }
        }
        int randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Count);
        int randomChild = UnityEngine.Random.Range(0, childrenObjectPrefabs.Length);
        var instanceGameObject = Instantiate(childrenObjectPrefabs[randomChild]);
        instanceGameObject.transform.position = spawnPoints[randomSpawn].position;
        touchToWin.transform.position = instanceGameObject.transform.position;
    }
}
