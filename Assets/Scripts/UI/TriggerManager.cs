using UnityEngine;
using System.Collections;

public class TriggerManager : MonoBehaviour
{
    public static bool spawn = false;
    [SerializeField]
    private GameObject nitrosTrigger;
    [SerializeField]
    private float spawnTime;
    private IEnumerator SpawnTrigger()
    {
        yield return new WaitForSeconds(spawnTime);
        //Spawn Trigger PreFab
        Instantiate(nitrosTrigger, this.transform.position, this.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(SpawnTrigger());
        }
    }
}
