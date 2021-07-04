using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class nutrition : MonoBehaviour
{

    private ARTrackedImageManager imagemanager;

    private void Awake()
    {
        imagemanager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        imagemanager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        imagemanager.trackedImagesChanged -= OnImageChanged;
    }

   
    public void OnImageChanged(ARTrackedImagesChangedEventArgs images)
    {
        
        foreach (var trackedImage in images.added)
        {
            current.barcode = trackedImage.referenceImage.name;
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }

        LoaderUtility.Deinitialize();
        LoaderUtility.Initialize();

    }
}
