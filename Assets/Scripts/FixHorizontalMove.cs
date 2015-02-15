using UnityEngine;
using System.Collections;

public class FixHorizontalMove : MonoBehaviour {


	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
	}
}
