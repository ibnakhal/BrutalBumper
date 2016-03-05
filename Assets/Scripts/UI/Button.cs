using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour {
    [SerializeField]
    private int arcadeLevel;
    [SerializeField]
    private int splitLevel;
    [SerializeField]
    private GameObject confirmPanel;
    [SerializeField]
    private GameObject confirmButton1;
    [SerializeField]
    private GameObject confirmButton2;
    [SerializeField]
    private DataHolder data;
    public void Arcade()
    {
        data.totalPlayers = 1;
        SceneManager.LoadScene(arcadeLevel);
    }
    public void Confirm()
    {
        confirmPanel.SetActive(true);
        confirmButton1.SetActive(true);
        confirmButton2.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void SplitScreen()
    {
        data.totalPlayers = 2;
        SceneManager.LoadScene(splitLevel);

    }
    public void Denied()
    {
        confirmPanel.SetActive(false);
        confirmButton1.SetActive(false);
        confirmButton2.SetActive(false);
    }
}
