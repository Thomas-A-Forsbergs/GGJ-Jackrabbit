using UnityEngine;

public class PlayerLookAtCamera : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
    }
}
