﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	Camera sceneCamera;

	[SerializeField]
	Behaviour[] componentsToDisable;

	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) {
			for (int i = 0; i < componentsToDisable.Length; i++) {
				componentsToDisable [i].enabled = false;
			}
		} else {
			sceneCamera = Camera.main;
			if (sceneCamera != null) {
				sceneCamera.gameObject.SetActive(false);
			}
		}
	}

	void onDisable () {
		if (sceneCamera != null) {
			sceneCamera.gameObject.SetActive(true);
		}
	}
}
