using UnityEngine;
using System.Collections;

public class remains_spray_none_gravity : MonoBehaviour {
	
	private float x;
	protected float y;
	private int[] y_dir = new int[2];
	private int y_dir_idx;
	public Vector2 direction;
	public float speed;

	// Use this for initialization
	void Start () {
		setDirectionAndSpeed();
		setGravity();
		destroyObj();
	}
	
	protected void setDirectionAndSpeed() {
		setXY();
		setSpeed();
		direction = new Vector2(x,y);
		rigidbody2D.velocity = direction*speed;
	}
	
	protected virtual void setXY(){
		y_dir[0] = -1;
		y_dir[1] = 1;
		x = Random.Range(-255,255) / 255f;
		y_dir_idx = Random.Range(0,255) / 255f > 0.5 ? 1: 0;
		y = y_dir[y_dir_idx] * Mathf.Sqrt(2 - x*x);
	}
	
	protected virtual void setSpeed(){
		speed = Random.Range(1,10);
	}
	
	protected virtual void destroyObj(){
		Destroy(gameObject, 3f);
	}
	
	protected virtual void setGravity(){
		rigidbody2D.gravityScale = 0.1f;
	}
}
