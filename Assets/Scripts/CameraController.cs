using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {



	// Update is called once per frame
	void Update () {
		foreach(GameObject gb in GameObject.FindGameObjectsWithTag("Player"))
		{
				transform.position = new Vector3(gb.transform.position.x, gb.transform.position.y, transform.position.z);

		}



	}
}
