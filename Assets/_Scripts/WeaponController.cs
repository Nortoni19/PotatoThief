using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

	
	
	
	void Update () 
    { 
        SetPos();

	}
   void SetPos() 
   {
        transform.position = player.transform.position + offset;
   }
}
