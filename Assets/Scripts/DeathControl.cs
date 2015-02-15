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
		// before delete the object, separate the gravity control
		Transform gravityInstance =  gameObject.transform.FindChild ("GravitySphere(Clone)");
		if (!gravityInstance) {
			Debug.Log("GRAVITY: NO CHILDREN Named GravitySphere");
			Destroy (gameObject);
			return;
		}
		else {
			// remove relation
			Debug.Log("GRAVITY: Detach GravitySphere");
			gravityInstance.SetParent(transform.parent);
			gravityInstance.GetComponent<AntiGravityControl>().deallocateSphere();
			Destroy (gameObject);
		}

	}


}
