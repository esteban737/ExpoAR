using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class PlaceOnPlane : MonoBehaviour
{
    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }

    void Awake()
    {
        m_AnchorManager = GetComponent<ARAnchorManager>();
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_PlaneManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        print("press");
        if (Input.touchCount <= 0)
            return;
        //else if (Input.touchCount > 1) {
        //    if (spawnedObject != null) {
        //        // Store both touches.
        //        Touch touchZero = Input.GetTouch(0);
        //        Touch touchOne = Input.GetTouch(1);
        //        // Calculate previous position
        //        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
        //        // Find the magnitude of the vector (the distance) between the touches in each frame.
        //        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
        //        // Find the difference in the distances between each frame.
        //        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
        //        float pinchAmount = deltaMagnitudeDiff * 0.02f * Time.deltaTime;
        //        spawnedObject.transform.localScale -= new Vector3(pinchAmount, pinchAmount, pinchAmount);
        //        // Clamp scale
        //        float Min = 0.005f;
        //        float Max = 3f;
        //        spawnedObject.transform.localScale = new Vector3(
        //            Mathf.Clamp(spawnedObject.transform.localScale.x, Min, Max),
        //            Mathf.Clamp(spawnedObject.transform.localScale.y, Min, Max),
        //            Mathf.Clamp(spawnedObject.transform.localScale.z, Min, Max)
        //        );
        //    }
        //}
        else if (Input.touchCount == 1) {
            if (m_RaycastManager.Raycast(Input.GetTouch(0).position, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hit = s_Hits[0];

                m_Anchors.Add(m_AnchorManager.AttachAnchor(m_PlaneManager.GetPlane(hit.trackableId), hit.pose));

                m_PlaneManager.enabled = false;
                foreach (var plane in m_PlaneManager.trackables)
                    plane.gameObject.SetActive(false);

                //if (spawnedObject == null)
                //{
                //    spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                //}
                //else
                //{
                //    spawnedObject.transform.position = hitPose.position;
                //}
            }
        }
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    public List<ARAnchor> m_Anchors = new List<ARAnchor>();

    ARAnchorManager m_AnchorManager;
    ARRaycastManager m_RaycastManager;
    ARPlaneManager m_PlaneManager;
}