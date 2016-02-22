﻿using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class CameraControl : MonoBehaviour {

    public TransformGesture ScrnTran;
    public Transform Camera;
    public bool transforming;

	// Use this for initialization
	void Start () {
        ScrnTran.Transformed += ScrnTran_Transformed;
    }

    private void ScrnTran_Transformed(object sender, System.EventArgs e)
    {
        ScrnTran.ApplyTransform(Camera);
    }

    // Update is called once per frame
    void Update () {
	
	}
}