using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TrapSpawn : MonoBehaviour {
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    public List<GameObject> theList;
    [SerializeField]
    private GameObject[] Spawnable;
    [SerializeField]
    private int fieldMaximum;
    [SerializeField]
    private float timeWave;

    [SerializeField]
    private SpawnLocalControl locCon;

    // Use this for initialization
	void Start () {
        StartCoroutine(Cycle());
	}
	private IEnumerator Cycle()
    {
        while(isActiveAndEnabled)
        {
            yield return new WaitForSeconds(timeWave);
            if(theList.Count < fieldMaximum)
            {
                int rando = Random.Range(0, Spawnable.Length);
                int randSpawn = Random.Range(0, spawnPoints.Length);
                while(spawnPoints[randSpawn].GetComponent<SpawnLocalControl>().taken)
                {
                    randSpawn = Random.Range(0, spawnPoints.Length);

                }
                GameObject clone = Instantiate(Spawnable[rando], spawnPoints[randSpawn].position, Quaternion.identity) as GameObject;
                spawnPoints[randSpawn].GetComponent<SpawnLocalControl>().taken = true;
                clone.transform.SetParent(spawnPoints[randSpawn]);
                theList.Add(clone);
            }
        }
    }
}
