using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	[SerializeField] Transform target;
	[SerializeField] float height = 10f;
	[SerializeField] float followDistance = -10f;

	

	void Update () {
		
		MoveCamera ();
		transform.LookAt (target);
	}

	void MoveCamera ()
	{
		
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y + height, target.transform.position.z + followDistance);
	
			
	}

}
