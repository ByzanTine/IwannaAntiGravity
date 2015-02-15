using UnityEngine;
using System.Collections;

public class AntiGravityControl : MonoBehaviour {

	public enum GravityState {
		ExitReset,
		ExitHold
	}
	public GravityState gravityState = GravityState.ExitReset;

	public float standardScale = 1.0f;

	public bool sphereEnabled = false; // circle enabled 

	private bool changing = false;

	private float standardRadius;
	void Start () {

		standardRadius = GetComponent<CircleCollider2D> ().radius;
		GetComponent<CircleCollider2D> ().radius = 0.0f;
		transform.localScale = new Vector3 (0, 0, 0);
		toggleSphereActive ();
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.tag == "Movable") {
			// Debug.Log("Something in here");
			coll.gameObject.rigidbody2D.gravityScale = -1.0f;

		}
	}
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.tag == "Movable") {
			// Debug.Log("Something in here");
			if (gravityState == GravityState.ExitReset) {
				coll.gameObject.rigidbody2D.gravityScale = 1.0f;
			}
			else if (gravityState == GravityState.ExitHold)
				coll.gameObject.rigidbody2D.gravityScale = -1.0f;
		}
	}
	public void toggleSphereActive () {
		// shrink
		if (changing)
			return;

		if (sphereEnabled) {
			sphereEnabled = false;
			changing = true;

			StartCoroutine(changeScale(transform.localScale, new Vector3(0, 0, 0), 
			               standardRadius, 0.0f));


		}
		else {
			sphereEnabled = true;
			changing = true;
			StartCoroutine(changeScale(transform.localScale, new Vector3(1, 1, 1), 
			                           0.0f, standardRadius));
		}

		// disable 
	}

	// change the collider as well
	IEnumerator changeScale (Vector3 fromScale, Vector3 toScale, float fromRadius, float toRadius, float time = 1.0f) {

		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.fixedDeltaTime * rate;
			transform.localScale = Vector3.Lerp(fromScale, toScale, i);
			GetComponent<CircleCollider2D>().radius = Mathf.Lerp(fromRadius, toRadius, i);
			// Debug.Log("Lerp once" + i);
			yield return null;
		}
		changing = false;
	}

	public void deallocateSphere() { 
		StartCoroutine(changeScale(transform.localScale, new Vector3(0, 0, 0), 
		                           standardRadius, 0.0f));
		Destroy (gameObject, 2.0f);
	}


}
