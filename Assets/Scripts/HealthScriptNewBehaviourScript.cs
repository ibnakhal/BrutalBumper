using UnityEngine;
using System.Collections;

public class HealthScriptNewBehaviourScript : MonoBehaviour {
    [SerializeField]
    private int Health;
    [SerializeField]
    private ParticleSystem deathParticles;
    [SerializeField]
    private GameObject deadMesh;
     

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Health<=0)
        {/*
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Instantiate(deadMesh, transform.position, transform.rotation);
            
            */
            Destroy(this);
        }
	}



    public void GetHurt(int damage)
    {
        Health -= damage;
    }
}
