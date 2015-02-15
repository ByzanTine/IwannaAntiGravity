using UnityEngine;
using System.Collections;

public class SavePointController : MonoBehaviour {

	Animator anim;
	private PlayerSaving playerSaving;
	void Start()
	{
		anim = GetComponent<Animator> ();

		GameObject savingObject= GameObject.Find("PlayerSaving");
		playerSaving = savingObject.GetComponent<PlayerSaving>();
	}
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "Player"){

			anim.SetBool("Save", true);
			// Debug.Log (t.localPosition.ToString());
			
			playerSaving.savePosition = coll.gameObject.transform.position;
			Debug.Log("SAVE: Set isSavePositionSaved to true");
			playerSaving.isSavePositionSaved = true;

		}
	}
	void OnTriggerExit2D (Collider2D coll) {
		if (coll.tag == "Player"){
			anim.SetBool("Save", false);

		}
	}
}
