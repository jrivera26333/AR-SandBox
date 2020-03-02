using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{
    ARTrackedImageManager _arTrackedImageManager;

    private void Awake()
    {
        _arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    /// <summary>
    /// If an Image has been added, updated, or removed call this function
    /// </summary>
    /// <param name="args"></param>
    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        //Added is when the image if first seen
        //Updated is when the object is moving so its updating its position
        //Removed is when the card is taken away from the screen
        foreach(var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
        }
    }
}
