using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour {
    [SerializeField]
    public int totalPlayers;
    [SerializeField]
    public int p1Char;
    [SerializeField]
    public int p2Char;
    [SerializeField]
    public int playerCounter;
    [SerializeField]
    public bool p1Select;
    [SerializeField]
    public bool p2Select;
    [SerializeField]
    private int sceneSelection;
    [SerializeField]
    private bool SceneSelected;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
        if(playerCounter >= totalPlayers && !SceneSelected)
        {
            SceneManager.LoadScene(sceneSelection);
            SceneSelected = true;
        }


	}




}
