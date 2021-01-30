using UnityEngine;

public class ChangeCameraZoom : MonoBehaviour
{
    public KeyCode[] keysToChangeZoom;
    public float[] zoomLevels;
    private int _index;

    private void Update()
    {
        foreach (var keyCode in keysToChangeZoom)
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (_index < zoomLevels.Length - 1)
                    _index++;
                else
                    _index = 0;
                GetComponent<MSCameraController>().cameraSettings.OrbitalThatFollows.maxDistance = zoomLevels[_index];
                GetComponent<MSCameraController>().cameraSettings.OrbitalThatFollows.minDistance = zoomLevels[_index];
            }
        }
        
    }
}
