using UnityEngine;
using System.Collections;

public class InfoPasser : MonoBehaviour
{
    public enum Controls
    {
        OneKeyboard, OneXbox, KeyboardAndXbox, DoubleXbox
    };
    public struct InfoToPass
    {
        private int NumPlayers;
        private Controls HowToPlay;
        public void SetPlayers(int x) { NumPlayers = x; }
        public void SetControls(Controls c) { HowToPlay = c; }
        public int GetNumPlayers() { return NumPlayers; }
        public Controls GetHowToPlay() { return HowToPlay; }
    }
    public InfoToPass MyInfo;
    // Use this for initialization
    void Start()
    {
        MyInfo = new InfoToPass();
        MyInfo.SetControls(Controls.OneXbox);
        MyInfo.SetPlayers((int)1);
        DontDestroyOnLoad(this.gameObject);
    }
}
