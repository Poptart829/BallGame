using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerSelectionScript : MonoBehaviour
{
    public Canvas BaseCanvas;
    public Canvas OnePlayerCanvas;
    public Canvas TwoPlayerCanvas;

    public Button OneKeyboard;
    public Button OneXbox;

    public Button TwoKeybaord;
    public Button TwoXbox;

    public GameObject InfoToPassOn;
    private InfoPasser info;
	// Use this for initialization
	void Start ()
    {
        BaseCanvas = BaseCanvas.GetComponent<Canvas>();
        OnePlayerCanvas = OnePlayerCanvas.GetComponent<Canvas>();
        TwoPlayerCanvas = TwoPlayerCanvas.GetComponent<Canvas>();

        OneXbox = OneXbox.GetComponent<Button>();
        OneKeyboard = OneKeyboard.GetComponent<Button>();

        TwoXbox = TwoXbox.GetComponent<Button>();
        TwoKeybaord = TwoKeybaord.GetComponent<Button>();
        OnePlayerCanvas.gameObject.SetActive(false);
        TwoPlayerCanvas.gameObject.SetActive(false);
        OneKeyboard.gameObject.SetActive(false);
        OneXbox.gameObject.SetActive(false);
        TwoKeybaord.gameObject.SetActive(false);
        TwoXbox.gameObject.SetActive(false);
        info = InfoToPassOn.GetComponent<InfoPasser>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnOneClick()
    {
        OneKeyboard.gameObject.SetActive(true);
        OneXbox.gameObject.SetActive(true);
        OnePlayerCanvas.gameObject.SetActive(true);
        BaseCanvas.gameObject.SetActive(false);
        info.MyInfo.SetPlayers((int)1);
    }

    public void OnTwoClick()
    {
        TwoXbox.gameObject.SetActive(true);
        TwoKeybaord.gameObject.SetActive(true);
        TwoPlayerCanvas.gameObject.SetActive(true);
        BaseCanvas.gameObject.SetActive(false);
        info.MyInfo.SetPlayers((int)2);

    }

    public void OnOneKeyBoardClick()
    {
        info.MyInfo.SetControls(InfoPasser.Controls.OneKeyboard);
        SceneManager.LoadScene("_play");
    }

    public void OnOneXboxClick()
    {
        info.MyInfo.SetControls(InfoPasser.Controls.OneXbox);
        SceneManager.LoadScene("_play");
    }

    public void OnTwoKeyboardClick()
    {
        info.MyInfo.SetControls(InfoPasser.Controls.KeyboardAndXbox);
        SceneManager.LoadScene("_play");
    }

    public void OnTwoXboxClick()
    {
        info.MyInfo.SetControls(InfoPasser.Controls.DoubleXbox);
        SceneManager.LoadScene("_play");
    }
}
