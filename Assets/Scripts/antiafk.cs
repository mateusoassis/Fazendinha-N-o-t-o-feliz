using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiafk : MonoBehaviour
{
    public float timeToSpawn;
	public float timer;
	public Rigidbody2D antiafkPrefab;
	public float speed;	
		
    void Update()
    {
        if(timer <= 0){
			
			Rigidbody2D clone;
		
			clone = Instantiate (antiafkPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
			clone.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
			
			timer = timeToSpawn;
			
		} else {
		
		timer -= Time.deltaTime;
		
		}
    }
}
