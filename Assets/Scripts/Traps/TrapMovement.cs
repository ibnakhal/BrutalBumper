using UnityEngine;
using System.Collections;

public class TrapMovement : MonoBehaviour {
    [SerializeField]
    private Vector3 rotationDir;
    [SerializeField]
    private float rotSpeed;
    [SerializeField]
    private float moveSpeed;
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationDir * Time.deltaTime * rotSpeed);
	}
}
