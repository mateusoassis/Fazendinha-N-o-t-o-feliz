using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancaFeno : MonoBehaviour
{
	public Rigidbody2D[] feno = new Rigidbody2D[2];
	public float speed;
		
    // Start is called before the first frame update
    void Start()
    {
		speed = 10f;
		
		lancaMan();
    }

    // Update is called once per frame
    void Update()
    {			
			
    }
	
	void lancaMan()
	{
		Rigidbody2D clone;
			
		int r = Random.Range(0,2);
		
		clone = Instantiate (feno[r], transform.position, Quaternion.identity) as Rigidbody2D;
		clone.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
	}
}
