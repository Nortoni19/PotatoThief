using UnityEngine;
using System.Collections;

public class PotatoController : MonoBehaviour {
	private Rigidbody rb;
	[SerializeField] float speed = 3.0f;
	[SerializeField] float jumpForce= 10.0f;


	void Start () 
	{
		rb = GetComponent <Rigidbody>();
	}

	void FixedUpdate()
	{
		movePotato ();
	}

	void movePotato () //moves ye old potato
	{
		
	float moveX = Input.GetAxis ("Horizontal");
	float moveZ = Input.GetAxis ("Vertical");
	float jumpY = 0.0f;
	
	


		if (Input.GetKeyDown("space") && OnGround() ) 
		{
			jumpY = jumpForce;
		}		

		if (OnGround ()) 
		{
			Vector3 movement = new Vector3 (moveX, jumpY, moveZ);
				
			rb.AddForce (movement * speed);
		}
		else
		{
			Vector3 movement = new Vector3 (moveX, jumpY, moveZ);

			rb.AddForce (movement * (speed/2));
		}
			
	}
	bool OnGround ()
	{

		return Physics.Raycast (transform.position, Vector3.down, GetComponent<MeshCollider>().bounds.extents.y + 0.1f);

	}
}
