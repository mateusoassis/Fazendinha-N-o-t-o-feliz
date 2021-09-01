using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cenario : MonoBehaviour
{
    public float timeToSpawn;
	public float timer;
	public Rigidbody2D obstaclesPrefab;
	public float speed;
	public float variation;

    void Update()
    {
        if(timer <= 0){
			
			Rigidbody2D clone;
		
			clone = Instantiate (obstaclesPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
			clone.AddForce(Vector3.left * speed, ForceMode2D.Impulse);
			
			variation = Random.Range(1f,5f);
			timer = timeToSpawn + variation;
			
		} else {
		
		timer -= Time.deltaTime;
		
		}
    }
}
