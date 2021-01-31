using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomizeALevel : MonoBehaviour
{
    public List<GameObject> levelPrefabs;

    private void Awake()
    {
        var random = Random.Range(0, levelPrefabs.Count);
        Instantiate(levelPrefabs[random]);
    }
}
