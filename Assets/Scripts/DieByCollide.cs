using UnityEngine;
using System.Collections;

public class DieByCollide : MonoBehaviour {


	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Player"){
			Debug.Log ("DEATH: Hi Collide on Spike");
			DeathControl deathControl = coll.gameObject.GetComponent<DeathControl>();
			if (deathControl) {
				deathControl.OnDeath();
			}

		}
	}
}
