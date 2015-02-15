using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;
	public bool facingRight = true;
	// Use this for initialization
	private Animator anim;
	public bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.02f;
	public LayerMask whatIsGround;
	public float jumpForce;

	public bool doubleJump = false;

	public float maxJumpPressInterval = 0.3f;
	public float secondJumpDecay = 0.82f;

    Camera camera;
	void Start () {
		anim = GetComponent<Animator> ();
		// reset all Moveable Object gravity Scale
		GameObject[] moveables = GameObject.FindGameObjectsWithTag("Movable");
		foreach(GameObject moveable in moveables) {
			moveable.rigidbody2D.gravityScale = 1.0f;
		}
	}
	
	// FixedUpdate is called once per frame
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		if (grounded){
			doubleJump = false;

		}
		anim.SetBool ("Ground", grounded);
		float move = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2(move*speed, rigidbody2D.velocity.y);
		if(move > 0 && !facingRight)
			Filp();
		else if (move < 0 && facingRight)
			Filp();
	}
	void Update()
	{


		if(Input.GetKeyDown(KeyCode.Z))
		{
			if ((grounded || !doubleJump)){
				
				
				anim.SetBool("Ground", false);
				// Debug.Log ("jump Velo:" + jumpForce);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
				if (!doubleJump && ! grounded){
					Debug.Log ("Double Jump Now");
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y*secondJumpDecay);
					doubleJump = true;
				}
			}

		}
		else if(Input.GetKeyUp(KeyCode.Z))
		{

			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y*0.45f);
		}
	}
	void Filp(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
