using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    private PlayerMovement playerRef;

    [SerializeField] private float launchForce = 2f;

    private void Start()
    {
        //needed in order to be switched on and off
    }

    private void OnEnable()
    {
        this.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnDisable()
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            playerRef = other.gameObject.GetComponent<PlayerMovement>();
            playerRef.isStuck = true;
            SlideLetGo();
        }
    }

    void SlideLetGo()
    {
        playerRef.GetComponent<Rigidbody>().AddForce(this.transform.forward * launchForce);
        playerRef.isStuck = false;
        playerRef = null;
    }
    
    
    /*
     *
     *void OnTriggerEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerRef = other.gameObject.GetComponent<PlayerMovement>();
            playerRef.isStuck = true;
            _eventHandler.SubscribeTo<SwingLetGoEvent>(SwingLetGo);
            _gotPlayerEvent = new GotPlayerEvent();
            _eventHandler.Publish(_gotPlayerEvent);
        }
    }
     * 
     *void SwingLetGo(SwingLetGoEvent argument)
    {
        this.GetComponentInChildren<SlideObstacle>().gameObject.SetActive(true);
        playerRef.GetComponent<Rigidbody>().AddForce(this.transform.forward * launchForce);
        playerRef.isStuck = false;
        playerRef = null;
        _gotPlayerEvent = null;
        _eventHandler.UnsubscribeFrom<SwingLetGoEvent>(SwingLetGo);
    }
     * 
     */
}