using UnityEngine;
using System.Collections;

public class CharacterButton : MonoBehaviour {
    [SerializeField]
    private AudioClip[] selectionRange;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private int characterNumber;
    [SerializeField]
    private bool taken;
    [SerializeField]
    private DataHolder data;

    public void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataHolder>();
    }
    public void blerb()
    {
        if (!taken)
        {
            StartCoroutine(buttonSelection());
            taken = true;
            if (!data.p1Select)
            {
                data.p1Select = true;
                
            }
            else
            {
                data.p2Select = true;
            }
        }
    }
public IEnumerator buttonSelection()
    {
        int rando = Random.Range(0, selectionRange.Length);
        source.clip = selectionRange[rando];
        source.Play();
        yield return new WaitForSeconds(selectionRange[rando].length);
                data.playerCounter++;
    }
}
