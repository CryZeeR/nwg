public void SpawnItem (int id, NetworkTransform ntransform, string prefab)
	{
		GameObject itemPrefab = null;
		
		itemPrefab = (GameObject)Resources.Load ("Items/" + prefab, typeof(GameObject));
		
		GameObject itemObj = GameObject.Instantiate (itemPrefab) as GameObject;
		itemObj.transform.position = ntransform.Position;
		itemObj.transform.localEulerAngles = ntransform.AngleRotationFPS;
		items[id] = itemObj;
	}
