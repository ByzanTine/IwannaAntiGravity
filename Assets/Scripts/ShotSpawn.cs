using UnityEngine;
using System.Collections;

public class ShotSpawn : MonoBehaviour {

	public GameObject bullet;
	public Transform shotTransform;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X)){
			GameObject ob = Instantiate (bullet) as GameObject;
			ob.transform.position = shotTransform.position;
		}


	}
}
