using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedBoost = 10;
    [SerializeField]
    private float maxNitros = 4000;
    [SerializeField]
    private int nitrosBoost = 100;

    private float nitros;
    private float trueSpeed;
    private bool canBoost;

    [SerializeField]
    private float turnspeed;
    [SerializeField]
    public Rigidbody rb;

    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
        trueSpeed = speed;
        nitros = maxNitros;
	}
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
        if(nitros > maxNitros)
        {
            nitros = maxNitros;
        }
        if(nitros <= 0)
        {
            canBoost = false;
        }
        else
        {
            canBoost = true;
        }
        if (canBoost)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                speed = speedBoost;
                StartCoroutine(Boost());
            }
            else
            {
                speed = trueSpeed;
            }
        }
        else
        {
            speed = trueSpeed;
        }
        print(nitros);
    }
    private IEnumerator Boost()
    {
        nitros = nitros - 1;
        yield return new WaitForSeconds(0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NitrosTrigger")
        {
            nitros += nitrosBoost;
            Destroy(other.gameObject);
        }
    }
}
