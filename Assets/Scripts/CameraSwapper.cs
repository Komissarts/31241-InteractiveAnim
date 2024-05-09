using UnityEngine;
using UnityEngine.Playables;

public class CameraSwapper : MonoBehaviour
{
    public Camera[] cameras; // Array of cameras to swap between
    public Transform cameraViewpoint; // The single material/object that the cameras will view from
    public PlayableDirector[] sequencers; // Array of sequencers/timelines, one for each camera

    private int currentCameraIndex = 0;

    void Start()
    {
        // Set up initial camera and sequencer
        SetupCamera(currentCameraIndex);
    }

    void Update()
    {
        // Swap camera on input (e.g., keyboard or controller input)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapCamera();
        }
    }

    void SwapCamera()
    {
        // Reset the current sequencer
        sequencers[currentCameraIndex].Stop();

        // Move to the next camera in the array
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Set up the new camera and sequencer
        SetupCamera(currentCameraIndex);
    }

    void SetupCamera(int index)
    {
        // Position the camera at the viewpoint
        cameras[index].transform.position = cameraViewpoint.position;
        cameras[index].transform.rotation = cameraViewpoint.rotation;

        // Enable the camera
        cameras[index].gameObject.SetActive(true);

        // Play the corresponding sequencer
        sequencers[index].Play();
    }
}