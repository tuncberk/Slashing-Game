﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

	private static ScreenshotHandler instance;
	private bool takeScreenshotOnNextFrame;
	
	private Camera myCamera;

	private void Awake(){
		instance = this;
		myCamera = gameObject.GetComponent<Camera>();
	}
	private void OnPostRender(){
		if (takeScreenshotOnNextFrame){
			takeScreenshotOnNextFrame = false;
			RenderTexture renderTexture = myCamera.targetTexture;

			Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
			Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
			renderResult.ReadPixels(rect, 0, 0);

			byte[] byteArray = renderResult.EncodeToPNG();
			System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshot.png", byteArray);
			Debug.Log("Saved CameraScreenshot.png");

			RenderTexture.ReleaseTemporary(renderTexture);
			myCamera.targetTexture = null;
		}
	}
	private void  TakeScreenShot(int width, int height){
		myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
		takeScreenshotOnNextFrame = true;
	}
	public static void TakeScreenShot_Static (int width, int height){
		instance.TakeScreenShot(width, height);
	}
}
