﻿using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {


	//回転速度
	private float rotSpeed = 1.0f;
	// Use this for initialization
	void Start () {
			//回転を開始うる角度を設定
		this.transform.Rotate(0, Random.Range (0, 360), 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, this.rotSpeed, 0);
	}
}
