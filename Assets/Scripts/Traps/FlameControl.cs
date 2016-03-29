using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FlameControl : MonoBehaviour {
    [SerializeField]
    private List<ParticleSystem> PSystem;
    [SerializeField]
    private FlameTrap fTrap;
    [SerializeField]
    private bool fSwitch;

	// Use this for initialization
	void Start () {
        PSystem.AddRange(GetComponentsInChildren<ParticleSystem>());
        fTrap = GetComponentInChildren<FlameTrap>();
	}
	void Update()
    {

    }

    public void ShutDown()
    {
        if  (fSwitch)
        {
            for (int x = 0; x < PSystem.Count; x++)
            {
                PSystem[x].Stop();
                fSwitch = false;
            }
        }
        else
        {
            for (int x = 0; x < PSystem.Count; x++)
            {
                PSystem[x].Play();
                fSwitch = true;
            }
        }
       
       

    }

}
