using System.Linq.Expressions;
using UnityEngine;

public class SlideObstacle : MonoBehaviour
{
    private PlayerMovement playerRef;

    [SerializeField] private float launchForce = 2f;

    private void Start()
    {
        
    }

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
        playerRef.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        playerRef.GetComponent<Rigidbody>().AddForce(this.transform.forward * launchForce);
        playerRef = null;
    }
}