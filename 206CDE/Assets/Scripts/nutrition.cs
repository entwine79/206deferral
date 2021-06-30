using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class nutrition : MonoBehaviour
{
    public static string storedimage;

    private ARTrackedImageManager _aRTrackedImageManager;

    private void Awake()
    {
        _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        _aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

   
    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
            if (trackedImage.name.Equals("VanillaFrosting"))
            {
                storedimage = trackedImage.name;
            }
        }

        //SceneManager.LoadScene(5, LoadSceneMode.Single);

        LoaderUtility.Deinitialize();
        LoaderUtility.Initialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(5);

    }
}
