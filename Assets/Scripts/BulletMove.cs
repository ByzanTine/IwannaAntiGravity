using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public Vector2 direction;
	public PlayerController player;
	public float speed;
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		rigidbody2D.velocity =(player.facingRight?1:-1) *direction*speed;
	}


}
