using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnspeed;
    [SerializeField]
    public Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

            Vector3 thrustV = this.gameObject.transform.forward;
            thrustV.y = 0.0f;
            rb.AddForce(thrustV * speed * v);
        //transform.Translate(transform.forward * speed * Time.deltaTime);
        if (h != 0)
        {
            if (rb.velocity != Vector3.zero)
            {
                if (v >= 0)
                {
                    Debug.Log("Torque!");
                    this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * h);
                }
                if (v <= 0)
                {
                    this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * -h);

                }
            }
        }

    }
}
