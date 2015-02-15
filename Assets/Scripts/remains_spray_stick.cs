using UnityEngine;
using System.Collections;

public class remains_spray_stick : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		
		if (coll.tag == "DeadBody"){
			coll.gameObject.rigidbody2D.velocity = new Vector3(0,0,0);
			coll.gameObject.rigidbody2D.gravityScale = 0;
		}
	}
}
