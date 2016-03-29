using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button2P : MonoBehaviour {
    [SerializeField]
    private int level;

    public void Load()
    {
        SceneManager.LoadScene(level);
    }
}
