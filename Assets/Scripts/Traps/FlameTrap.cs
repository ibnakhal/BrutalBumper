using UnityEngine;
using System.Collections;

public class FlameTrap : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float damgeTime = 1;
    private bool isDamaging = true;
    private HealthScriptNewBehaviourScript health = null;
    [SerializeField]
    public bool active = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && active)
        {
            // Grab the script of the player being hit.
           health = other.GetComponent<HealthScriptNewBehaviourScript>();
            if(isDamaging)
            {
                StartCoroutine(FireDamage());
            }
        }
    }
    private IEnumerator FireDamage()
    {
        health.GetHurt(damage);
        isDamaging = false;
        yield return new WaitForSeconds(damgeTime);
        isDamaging = true;
    }
}
