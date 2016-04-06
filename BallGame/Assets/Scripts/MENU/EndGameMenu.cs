using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public Button m_Replay;
    public Button m_Quit;

	// Use this for initialization
	void Start ()
    {
        m_Replay = m_Replay.GetComponent<Button>();
        m_Quit = m_Quit.GetComponent<Button>();
	}
	
    public void OnClickReplay()
    {
        SceneManager.LoadScene("_INTRO");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

}
