using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFeno : MonoBehaviour
{
	public float timeToSpawn;
	public float timer;
	public Rigidbody2D[] feno = new Rigidbody2D[2];
	public float speed;
	public Vector3 pos = new Vector3(-7, 4, 1);
		
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
			
			Rigidbody2D clone;
			
			int r = Random.Range(0,2);
		
			clone = Instantiate (feno[r], transform.position, Quaternion.identity) as Rigidbody2D;
			clone.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
			
			timer = timeToSpawn;
			
		} else {
		
		timer -= Time.deltaTime;
		
		}
    }
}
