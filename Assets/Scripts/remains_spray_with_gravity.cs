using UnityEngine;
using System.Collections;

public class remains_spray_with_gravity : remains_spray_none_gravity {

	protected override void setXY(){
		base.setXY();
		y = Mathf.Abs(y);
	}
	
	protected override void setSpeed(){
		speed = 1f;
	}
	
	protected override void setGravity(){
		rigidbody2D.gravityScale = 0.4f;
	}
	
	protected override void destroyObj(){
		Destroy(gameObject, 3f);
	}
}
