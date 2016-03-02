using UnityEngine;
using System.Collections;

public class CharacterButton : MonoBehaviour {
    [SerializeField]
    private AudioClip[] selectionRange;
    [SerializeField]
    private AudioSource source;
    public void blerb()
    {
        StartCoroutine(buttonSelection());
    }
public IEnumerator buttonSelection()
    {
        int rando = Random.Range(0, selectionRange.Length);
        source.clip = selectionRange[rando];
        source.Play();
        yield return new WaitForSeconds(selectionRange[rando].length);
    }
}
