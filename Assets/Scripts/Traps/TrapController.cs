using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour
{
    [SerializeField]
    private GameObject spikeTraps;
    [SerializeField]
    private GameObject flameTraps;
    [SerializeField]
    private GameObject flamePillars;

  /*private void Start()
    {
        spikeTraps = GameObject.FindGameObjectWithTag("spikeTraps");
        flameTraps = GameObject.FindGameObjectWithTag("flameTraps");
        flameTraps = GameObject.FindGameObjectWithTag("flamePillars");
    }*/
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

            if (percentage >= 1 && percentage <= 30)
            {
                spikeTraps.SetActive(true);
                flameTraps.SetActive(true);
                flamePillars.SetActive(false);
            }
            if (percentage >= 31 && percentage <= 60 )
            {
                spikeTraps.SetActive(true);
                flameTraps.SetActive(false);
                flamePillars.SetActive(true);
            }
            if(percentage >= 61 && percentage <= 90)
            {
                spikeTraps.SetActive(false);
                flameTraps.SetActive(true);
                flamePillars.SetActive(true);
            }
            if(percentage >= 91 && percentage <= 100)
            {
                spikeTraps.SetActive(true);
                flameTraps.SetActive(true);
                flamePillars.SetActive(true);
            }
        }
        Destroy(this.gameObject);
    }
}
