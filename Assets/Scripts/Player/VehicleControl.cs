using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnspeed;
    [SerializeField]
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.01f)
        {
            Vector3 thrustV = transform.forward;
            thrustV.y = 0.0f;
            rb.AddRelativeForce(thrustV * speed);
            //transform.Translate(transform.forward * speed * Time.deltaTime);
        }
	
	}
}
