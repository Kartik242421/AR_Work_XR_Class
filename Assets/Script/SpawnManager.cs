using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;          // Object to be spawned on AR plane
    private GameObject createdObject;         // Holds the spawned object
    private ARRaycastManager aRRaycastManager; // AR raycasting manager to detect planes

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();  // List to store raycast hits
    private bool planeDetectionEnabled = true;  // Flag to control plane detection

    private void Awake()
    {
        // Get ARRaycastManager component
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Check if there's a single finger touch and it's moving
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Rotate the spawned object
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            float rotationSpeed = 0.5f;

            if (createdObject != null)
            {
                createdObject.transform.Rotate(0, -touchDeltaPosition.x * rotationSpeed, 0, Space.World);
            }
        }

        // Handle plane detection and object spawning
        if (Input.touchCount > 0 && createdObject == null && planeDetectionEnabled)
        {
            var touchPosition = Input.GetTouch(0).position;

            if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                createdObject = Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);

                // Disable plane detection after object is spawned
                aRRaycastManager.enabled = false;
                planeDetectionEnabled = false;
            }
        }
    }
}
