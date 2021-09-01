using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingFeno : MonoBehaviour
{
	public float jumpingForce;
	private Rigidbody2D feno;
	public float timer;
	public float timeToJump;
	public float randomTime;
	
    void Start()
    {
        feno = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(timer <= 0){
			randomTime = Random.Range(0f,1f);
			feno.AddForce(jumpingForce * Vector3.up, ForceMode2D.Impulse);
			
			timer = timeToJump + randomTime;
			
		} else {
		
		timer -= Time.deltaTime;
		
		}
    }
}
