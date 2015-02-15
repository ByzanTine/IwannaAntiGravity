using UnityEngine;
using System.Collections;

public class PlayerSaving : MonoBehaviour {
	public Vector3 savePosition;
	public bool isSavePositionSaved = false;
	public GameObject playerPrefab;
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			// find out wether player already exist
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (!player) {
				Instantiate(playerPrefab, savePosition, Quaternion.identity);
			}
		}
	}
}
