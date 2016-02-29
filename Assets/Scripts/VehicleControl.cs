using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnspeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
	
	}
}
