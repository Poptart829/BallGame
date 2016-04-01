using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.gameObject.SetActive(false);
        exitText.gameObject.SetActive(false);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.gameObject.SetActive(true);
        exitText.gameObject.SetActive(true);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("_ControlSetUp");
    }

    public void ExitGame()
    {
        Application.Quit();
    }




	// Update is called once per frame
	void Update ()
    {
	
	}
}
