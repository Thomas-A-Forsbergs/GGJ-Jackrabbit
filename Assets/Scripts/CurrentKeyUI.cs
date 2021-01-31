using UnityEngine;
using UnityEngine.UI;

public class CurrentKeyUI : MonoBehaviour
{
    public KeyCodeToSprite[] sprites;
    public Image[] img;
    private void Awake()
    {
        FindObjectOfType<EventsBroker>().SubscribeTo(delegate(RandomKeyEvent keyEvent)
        {
            var amount = 0;
            foreach (var sprite in sprites)
            {
                if (amount > 1) return;
                if (keyEvent.ToString().Contains(sprite.KeyCode.ToString()))
                {
                    img[amount].sprite = sprite.Sprite;
                    amount++;
                }
                if (string.IsNullOrEmpty(sprite.Axis) || !keyEvent.ToString().Contains(sprite.Axis)) continue;
                img[amount].sprite = sprite.Sprite;
                amount++;
            }
        });
    }
}

[System.Serializable]
public class KeyCodeToSprite
{
    public KeyCode KeyCode;
    public string Axis;
    public Sprite Sprite;
}
