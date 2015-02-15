using UnityEngine;
using System.Collections;

public class DeadBodyController : MonoBehaviour {
	
	public int blood_num = 50;
	public GameObject[] body = new GameObject[5];
	public GameObject[] bloods = new GameObject[50];
	public Vector3 vec;
	public Quaternion rot = new Quaternion(0,0,0,0);

	// Use this for initialization
	void Start () {
        vec = gameObject.transform.position;
		body[0] = GameObject.Instantiate(Resources.Load("body_head"), vec, rot) as GameObject;
		body[1] = GameObject.Instantiate(Resources.Load("body_arL"), vec, rot) as GameObject;
		body[2] = GameObject.Instantiate(Resources.Load("body_arR"), vec, rot) as GameObject;
		body[3] = GameObject.Instantiate(Resources.Load("body_leL"), vec, rot) as GameObject;
		body[4] = GameObject.Instantiate(Resources.Load("body_leR"), vec, rot) as GameObject;
		sprayBlood();
		Destroy(gameObject, 3f);
	}
	
	void sprayBlood() {
		for (int i = 0; i < blood_num; i++){
			bloods[i] = GameObject.Instantiate(Resources.Load("blood"), vec, rot) as GameObject;
		}
	}
}
