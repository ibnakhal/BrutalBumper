using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrapController : MonoBehaviour
{
/*    [SerializeField]
    private GameObject spikeTraps;
  */[SerializeField]
    private List<GameObject> flameTraps;
    [SerializeField]
    private List<GameObject> flamePillars;

private void Start()
    {
        flameTraps.AddRange(GameObject.FindGameObjectsWithTag("flameTraps"));
        flamePillars.AddRange(GameObject.FindGameObjectsWithTag("flamePillars"));
    }
    /*private void Awake()
    {
        spikeTraps = GameObject.FindGameObjectWithTag("spikeTraps");
        flameTraps = GameObject.FindGameObjectWithTag("flameTraps");
        flamePillars = GameObject.FindGameObjectWithTag("flamePillars");
    }*/
    private void OnTriggerEnter(Collider other)
    {


        if ( other.tag == "Player")
        {


            int percentage = Random.Range(1, 100);

            if (percentage >= 1 && percentage <= 32)
            {
                foreach (GameObject obj in flameTraps)
                {
                    obj.GetComponent<FlameControl>().ShutDown();
                }
            }
            if (percentage >= 33 && percentage <= 65 )
            {
                foreach (GameObject obj in flamePillars)
                {
                    obj.GetComponent<FlameControl>().ShutDown();

                }
            }
            if(percentage >= 66 && percentage <= 100)
            {
                foreach (GameObject obj in flameTraps)
                {
                    obj.GetComponent<FlameControl>().ShutDown();
                }
                foreach (GameObject obj in flamePillars)
                {
                    obj.GetComponent<FlameControl>().ShutDown();

                }
            }
           /* if(percentage >= 91 && percentage <= 100)
            {
                foreach (GameObject obj in flameTraps)
                {
                    obj.GetComponent<FlameControl>().ShutDown();
                }
                foreach (GameObject obj in flamePillars)
                {
                    obj.GetComponent<FlameControl>().ShutDown();

                }
            }*/
        }
        Destroy(this.gameObject);
    }
}
