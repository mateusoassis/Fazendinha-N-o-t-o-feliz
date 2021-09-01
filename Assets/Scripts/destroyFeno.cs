using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFeno : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	//destruir feno que chega no chão
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "feno"){
			
			Destroy(other.gameObject, 2);
		}
	}
}
