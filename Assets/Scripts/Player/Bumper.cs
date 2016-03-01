using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

    [SerializeField]
    private GameObject parent;
    // Use this for initialization
    [SerializeField]
    private float force;
    [SerializeField]
    private float modifier;
    [SerializeField]
    private VehicleControl vControl;
	void Start () {
        vControl = parent.GetComponent<VehicleControl>();
	}
	
    public void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player" && Other.gameObject != parent)
        {
            Other.GetComponentInParent<VehicleControl>().rb.AddRelativeForce(transform.forward * force);
        }
    }



	// Update is called once per frame
	void Update () {

        force = (float)(vControl.rb.velocity.z * modifier);
	}
}
