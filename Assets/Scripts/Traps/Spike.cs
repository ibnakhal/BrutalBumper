using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {
    [SerializeField]
    private int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnCollisionEnter(Collision coolisioon)
    {
        Collider other = coolisioon.collider;
        other.GetComponent<HealthScriptNewBehaviourScript>().GetHurt(damage);
    }
}
