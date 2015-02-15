using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public Vector2 speed;

	void Update () {
		rigidbody2D.velocity = speed;
	}
}
