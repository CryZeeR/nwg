public void SpawnEnemy (int id, NetworkTransform ntransform, string name, string playerClass)
	{
		if (!players.ContainsKey (id)) {
			GameObject plObj = null;
			
			if (playerClass.Equals ("Human")) {
				plObj = GameObject.Instantiate (enemy2Prefab) as GameObject;
			} else {
				plObj = GameObject.Instantiate (enemyPrefab) as GameObject;
			}
			
			plObj.transform.position = ntransform.Position;
			plObj.transform.localEulerAngles = ntransform.AngleRotationFPS;
			AnimationSynchronizer animator = plObj.GetComponent<AnimationSynchronizer> ();
			animator.StartReceivingAnimation ();
			
			Enemy enemy = plObj.GetComponent<Enemy> ();
			enemy.Init (name, true);
			
			enemy.ShowInfo ();
			
			recipients[id] = plObj.GetComponent<NetworkTransformReceiver> ();
			players.Add (id, plObj);
		}
	}
