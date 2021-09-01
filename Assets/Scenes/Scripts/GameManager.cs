using UnityEngine;
using System.Collections;

public class GameManager: MonoBehaviour {

    public static GameManager instance;

    private int score;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Use this for initialization
    void Start () {
        score = GameManager.instance.score;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setScore(int pontuacao)
    {
        GameManager.instance.score = pontuacao;
    }

    public int getScore()
    {
        return GameManager.instance.score;
    }

}
