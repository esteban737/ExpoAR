using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class InputManager : MonoBehaviour
{
    // Reference to camera
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if there's been user input
        if (Input.GetMouseButtonDown(0))
        {
            // When the user taps on the screen, move the ray to that position
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            if (_raycastManager.Raycast(ray, _hits))
            {
                // Give position & rotation of the hit
                Pose pose = _hits[0].pose;
                Instantiate(DataHandler.Instance.merch, pose.position, pose.rotation);
            }
        }
    }
}
