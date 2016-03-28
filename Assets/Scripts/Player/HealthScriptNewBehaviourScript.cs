using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthScriptNewBehaviourScript : MonoBehaviour {
    [SerializeField]
    private int Health;
    [SerializeField]
    private GameObject deathParticles;
    [SerializeField]
    private GameObject deadMesh;
    [SerializeField]
    private Text hTxt;     

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Health<=0)
        {
            Health = 0;
            Instantiate(deathParticles, transform.position, Quaternion.identity);

            GameObject clone = Instantiate(deadMesh, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;
            
            
            Destroy(this.gameObject);
        }
        hTxt.text = ("Health: " + Health);
	}



    public void GetHurt(int damage)
    {
        Health -= damage;
    }
}
