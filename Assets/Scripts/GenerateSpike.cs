using UnityEngine;
using System.Collections;

public class GenerateSpike : MonoBehaviour {
	public GameObject spikePrefab;
	private float generateCoolDown = 1.0f;
	// using a cooldown to control glitches
	private float timer;
	void Start () {
		timer = Time.time;
	}
 	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.GetComponent<DeathControl>() && Time.time - timer > generateCoolDown) {
			timer = Time.time;
			Instantiate(spikePrefab, transform.position, Quaternion.identity);
		}

	}


}
