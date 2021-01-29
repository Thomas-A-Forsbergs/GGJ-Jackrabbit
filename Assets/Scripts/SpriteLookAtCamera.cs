using UnityEngine;

public class SpriteLookAtCamera : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
