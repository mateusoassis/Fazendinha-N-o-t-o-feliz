using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
	public int health;
	public int numberOfHearts;
	
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;
	
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }
	
	void Update(){
		
		for (int i= 0; i < hearts.Length; i++){
			if (i < health){
				hearts[i].sprite = fullHeart;
			} else {
				hearts[i].sprite = emptyHeart;
			
			if(i < numberOfHearts){
				hearts[i].enabled = true;
			} else {
				hearts[i].enabled = false;
			}
			}
		
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//choque com feno
		if(col.gameObject.tag == "feno")
		{
			health--;
			Destroy(col.gameObject, 0);
			if(health == 0){
				SceneManager.LoadScene("YouLoseScene");
				ScoreScript.scoreValue = 0;
			}
		} 
		//condição de vitória
		if(col.gameObject.tag == "victory"){
			SceneManager.LoadScene("YouWinScene");
			ScoreScript.scoreValue = 0;
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		//choque com o monstro antiafk
		if(coll.gameObject.tag == "antiafk")
		{
			SceneManager.LoadScene("YouLoseScene");
			ScoreScript.scoreValue = 0;
		} 
		
		if(coll.gameObject.tag == "obstacle")
		{
			health--;
			Destroy(coll.gameObject, 0);
			if(health == 0){
				SceneManager.LoadScene("YouLoseScene");
				ScoreScript.scoreValue = 0;
			}
		}
	}
}
