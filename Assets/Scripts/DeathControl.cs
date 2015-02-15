using UnityEngine;
using System.Collections;

public class DeathControl : MonoBehaviour {
	private PlayerSaving playerSaving;

	void Start() {
		GameObject savingObject = GameObject.Find("PlayerSaving");
		if (savingObject == null)
			return;
		playerSaving = savingObject.GetComponent<PlayerSaving>();
		
		// Debug.Log("positionSaved is " + playerSaving.isSavePositionSaved);
		if (playerSaving.isSavePositionSaved) {
			gameObject.transform.position = playerSaving.savePosition;
		}
	}

	public void OnDeath() {
		GameObject.Instantiate(Resources.Load("dead_body"), transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
