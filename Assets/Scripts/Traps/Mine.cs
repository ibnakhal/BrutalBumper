using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float damageRadius = 5;
    private HealthScriptNewBehaviourScript health = null;

    private void MineDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while(i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                health = hitColliders[i].GetComponent<HealthScriptNewBehaviourScript>();
                health.GetHurt(damage);
            }
            i++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MineDamage(this.transform.position, damageRadius);
            Destroy(this.gameObject);
            print("exploding");
            
        }
    }
}
