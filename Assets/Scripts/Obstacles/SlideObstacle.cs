using UnityEngine;

public class SlideObstacle : MonoBehaviour
{
    private PlayerMovement playerRef;

    [SerializeField] private float launchForce = 2f;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerRef = other.gameObject.GetComponent<PlayerMovement>();
            SlideLetGo();
        }
    }

    void SlideLetGo()
    {
        playerRef.GetComponent<Rigidbody>().AddForce(this.transform.forward * launchForce);
        playerRef = null;
    }
}