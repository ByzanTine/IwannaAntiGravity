using UnityEngine;
using System.Collections;

public class ChangePlayerState : MonoBehaviour {
	public GameObject blockWay;
	void Start () {
		blockWay.SetActive (false);
	}
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Player") {
			Debug.Log ("PLAYER_STATE: antigraivty state changed");
			coll.gameObject.GetComponentInChildren<AntiGravityControl>().gravityState 
					= AntiGravityControl.GravityState.ExitHold;
			blockWay.SetActive (true);
		}
	}
}
