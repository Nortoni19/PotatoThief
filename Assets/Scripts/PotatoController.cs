using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotatoController : MonoBehaviour {
	private Rigidbody rb;
	[SerializeField] float speed = 3.0f;
	[SerializeField] float jumpForce= 10.0f;
    public int score = 0;
    public Text scoreText;

	void Start () 
	{
		rb = GetComponent <Rigidbody>();
        score = 0;
        scoreText.text = "$" + score;
	}

	void FixedUpdate()
	{
		movePotato ();
	}
    void OnCollision(Collider other)
    {
        Debug.Log("beep");
        if (other.gameObject.CompareTag("JewelSmall")) {
           
        }

    }
    void OnTriggerEnter(Collider other) //checks the trigger collided with and adds score
    {
        //Debug.Log("b00p");
    
        if (other.gameObject.CompareTag ("JewelSmall")) 
        {
            score = score + 100;
            scoreText.text = "$" + score.ToString();
            other.gameObject.SetActive(false) ;
        }

       if (other.gameObject.CompareTag("JewelMedium"))
        {
            score = score + 500;
            scoreText.text = "$" + score.ToString();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("JewelLarge"))
        {
            score = score + 1000;
            scoreText.text = "$" + score.ToString();
            other.gameObject.SetActive(false);
        }

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
