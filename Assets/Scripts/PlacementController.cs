using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    [SerializeField] GameObject placedPrefab;
    ARRaycastManager arRayCastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject PlacePrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }

    private void Awake()
    {
        arRayCastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition)) { return; }

        if(arRayCastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        }
    }
}
