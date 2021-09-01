using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
	
	private playerMovement player;
	
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col)
	{
		
		if(col.name == "Player")
		{
			
			player.isLadder = true;
			
		}
		
	}
	void OnTriggerExit2D(Collider2D col)
	{
		
		if(col.name == "Player")
		{
			
			player.isLadder = false;
			
		}
		
	}
}
