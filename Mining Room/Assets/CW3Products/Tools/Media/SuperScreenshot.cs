using UnityEngine;
using System.Collections;


public class SuperScreenshot : MonoBehaviour {

	public int superSize = 2;
	public string fileName = "Screenshot.png";

	void Update() {
		if (Input.GetKeyDown("m"))
			ScreenCapture.CaptureScreenshot(fileName, superSize);
	}
}
