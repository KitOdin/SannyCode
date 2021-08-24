using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	private Rigidbody rb;
	public string PlatTag;
	private Vector3 Movement;
	public bool OnGround;
	public float Sensitvity;
	public bool Jumpable;
	public float movementSpeed;
	public float JumpHeight;
	public bool canMove;

	// Use this for initialization
	void Start ()
	{
		movementSpeed = Speed;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontalMovement = Input.GetAxisRaw ("Horizontal");
		float verticalMovement = Input.GetAxisRaw ("Vertical");
		float mouseRoation = Input.GetAxisRaw ("MouseX");
		
		
		base.transform.Rotate(0f, mouseRoation * Sensitvity, 0f);
		if(canMove)
		{
			Movement = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
		}
	}

	void FixedUpdate()
	{
		if(canMove)
		{
			Move ();
		}
		
	}

	void Move()
	{
		Vector3 yVelFix = new Vector3 (0, rb.velocity.y, 0);
		rb.velocity = Movement * movementSpeed * Time.deltaTime * 100f;
		rb.velocity += yVelFix;

		if (Jumpable && Input.GetKeyDown (KeyCode.Space) && OnGround) 
		{
			rb.AddForce (Vector3.up * JumpHeight, ForceMode.Impulse);
			OnGround = false;
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Ground")
		{
			OnGround = true;
		}
	}

	public void Jump()
	{
		if (Jumpable && OnGround) 
		{
			rb.AddForce (Vector3.up * JumpHeight, ForceMode.Impulse);
			OnGround = false;
		}
	}
}

