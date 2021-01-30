using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<EventsBroker>().SubscribeTo<WalkEvent>(WalkAnim);        
    }

    private void WalkAnim(WalkEvent walkEvent)
    {
        var left = walkEvent.CurrentWalkState == WalkEvent.WalkState.Left;
        GetComponent<Animator>().SetTrigger(left ? "LeftStepPressed" : "RightStepPressed");
    }
}
