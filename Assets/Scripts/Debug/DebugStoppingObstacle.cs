using UnityEngine;

public class DebugStoppingObstacle : MonoBehaviour
{
    private EventsBroker _eventHandler;

    void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _eventHandler.SubscribeTo<PlayerContextEvent>(LetGo);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerMovement>();
            if (player.isStuck != null) player.isStuck = true;
        }
    }

    void LetGo(PlayerContextEvent argument)
    {
        Debug.Log("Letting go of player");
    }
}
