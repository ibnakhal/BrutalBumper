using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject parent; 
	// Use this for initialization
	void Start () {
	
	}
	
    public void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player" && Other.gameObject != parent)
        {
            Other.GetComponent<HealthScriptNewBehaviourScript>().GetHurt(damage);
        }
    }



	// Update is called once per frame
	void Update () {
	
	}
}
