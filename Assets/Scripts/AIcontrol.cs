using UnityEngine;
using System.Collections;

public class AIcontrol : MonoBehaviour {
	float changeCoolDown = 0.5f;
	private float timer;
	private Vector2 Speed;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2 (1.0f, 0.0f);
		Speed = rigidbody2D.velocity;
		timer = Time.time;
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Untagged")
			return;
		if (Time.time - timer > changeCoolDown) {
			timer = Time.time;
			Debug.Log("Enter Trigger" + coll.tag);
			if (coll.tag == "Wall" || coll.tag == "Movable") {

				Speed.x *= -1;
				rigidbody2D.velocity = Speed;
			}

		}

	}
	void FixedUpdate() {
		rigidbody2D.velocity = Speed;
		Debug.Log (rigidbody2D.velocity);
	}
}
