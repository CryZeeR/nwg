public void SpawnPlayer (NetworkTransform ntransform, string name, int id, string playerClass)
	{
		if (!players.ContainsKey (id)) {
			if (Camera.main != null) {
				Destroy (Camera.main.gameObject);
			}
			
			if (playerClass.Equals ("Human")) {
				playerObj = GameObject.Instantiate (player2Prefab) as GameObject;
			} else {
				playerObj = GameObject.Instantiate (playerPrefab) as GameObject;
			}
			
			cameraObj = GameObject.Instantiate (cameraPrefab) as GameObject;
			playerObj.transform.position = ntransform.Position;
			playerObj.transform.localEulerAngles = ntransform.AngleRotationFPS;
			playerObj.SendMessage ("StartSendTransform");
			Debug.Log ("Player Instantiated...");
			players.Add (id, playerObj);
			playerObj.GetComponent<PlayerInfo> ().Init (NetworkManager.Instance.player.Name, true);
		}
	}
