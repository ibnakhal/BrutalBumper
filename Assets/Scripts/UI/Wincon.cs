 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Wincon : MonoBehaviour {
    [SerializeField]
    public List<GameObject> players;
    [SerializeField]
    private Text winText;
    [SerializeField]
    private bool gameOver = false;
	// Use this for initialization
	void Start () {
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));



	}
	
	// Update is called once per frame
	void Update () {
	if(players.Count == 1 && !gameOver)
        {
            winText.text = ("Player " + players[0].GetComponent<HealthScriptNewBehaviourScript>().playerNumber + " Wins!");
            gameOver = true;
        }
        if (players.Count == 0 && !gameOver)
        {
            winText.text = ("Draw");
            gameOver = true;
        }



    }
}
