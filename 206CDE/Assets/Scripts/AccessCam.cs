using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessCam : MonoBehaviour
{
	private bool iscamavailable;
	private WebCamTexture backCamera;
	private Texture defbg;

	public RawImage bg;
	public AspectRatioFitter fit;
	public bool frontFacing;

	// Use this for initialization
	void Start()
	{
		defbg = bg.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0)
			return;

		for (int i = 0; i < devices.Length; i++)
		{
			var curr = devices[i];

			if (curr.isFrontFacing == frontFacing)
			{
				backCamera = new WebCamTexture(curr.name, Screen.width, Screen.height);
				break;
			}
		}

		if (backCamera == null)
			return;

		backCamera.Play(); // Start the camera
		bg.texture = backCamera; // Set the texture

		iscamavailable = true; // Set the iscamavailable for future purposes.
	}

	// Update is called once per frame
	void Update()
	{
		if (!iscamavailable)
			return;

		float ratio = (float)backCamera.width / (float)backCamera.height;
		fit.aspectRatio = ratio; // Set the aspect ratio

		float scaleY = backCamera.videoVerticallyMirrored ? -1f : 1f; // Find if the camera is mirrored or not
		bg.rectTransform.localScale = new Vector3(1f, scaleY, 1f); // Swap the mirrored camera

		int orient = -backCamera.videoRotationAngle;
		bg.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
}
