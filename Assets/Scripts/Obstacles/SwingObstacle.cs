using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    private EventsBroker _eventHandler;
    private GotPlayerEvent _gotPlayerEvent;
    private PlayerMovement playerRef;

    [SerializeField] private float launchForce = 2f;
    
    void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerRef = other.gameObject.GetComponent<PlayerMovement>();
            if (playerRef.isStuck != null) playerRef.isStuck = true;
            _eventHandler.SubscribeTo<SwingLetGoEvent>(SwingLetGo);
            _gotPlayerEvent = new GotPlayerEvent();
            _eventHandler.Publish(_gotPlayerEvent);
        }
    }

    void SwingLetGo(SwingLetGoEvent argument)
    {
        // TODO: Need to NOT use Z-direction, but in stead use +-direction for launching
        Vector3 direction = this.transform.position;
        playerRef.GetComponent<Rigidbody>().AddForce(0,0, direction.z * launchForce);
        playerRef.isStuck = false;
        playerRef = null;
        _gotPlayerEvent = null;
        _eventHandler.UnsubscribeFrom<SwingLetGoEvent>(SwingLetGo);
    }
}
