using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public float timeToSpawn;
	public float timer;
	public Rigidbody2D obstaclesPrefab;
	public float speed;
	public float variation;
	
		
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
			
			Rigidbody2D clone;
		
			clone = Instantiate (obstaclesPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
			clone.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
			
			variation = Random.Range(1f,10f);
			timer = timeToSpawn + variation;
			
		} else {
		
		timer -= Time.deltaTime;
		
		}
    }
}