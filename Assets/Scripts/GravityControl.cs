using UnityEngine;
using System.Collections;

public class GravityControl : MonoBehaviour {
	public GameObject gravitySphere; 
	public GameObject gravityInstance;
	// Use this for initialization
	void Start () {
		gravityInstance = Instantiate(gravitySphere, transform.position, Quaternion.identity) as GameObject;
		gravityInstance.transform.SetParent(transform);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.S)) {
			// generate a sphere 
			if (gravityInstance) {

				gravityInstance.GetComponent<AntiGravityControl>().toggleSphereActive();

			}
		}

	}
}
