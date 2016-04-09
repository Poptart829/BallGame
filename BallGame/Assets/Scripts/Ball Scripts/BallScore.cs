using UnityEngine;
using System.Collections;

public class BallScore : MonoBehaviour
{
    private int m_Score = 0;
    private string baseString;
    private Rect ScorePosition = new Rect(10, 30, 200, 20);
    private CoinManager m_CoinManager;
    private WallTrigger m_EndGameWall;
    private int m_ScoreNeeded;
    // Use this for initialization
    void Start ()
    {
        baseString = "Player Score : ";
        m_CoinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        m_EndGameWall = GameObject.Find("EndWall").GetComponent<WallTrigger>();
        m_ScoreNeeded = m_CoinManager.m_ClearAmount;
    }

    // Update is called once per frame
    void Update ()
    {
	    
	}

    public void IncScore(int _amount)
    {
        m_Score += _amount;
        if(m_CoinManager.isDone(m_Score))
        {
            m_EndGameWall.GetWall().StartMovement = true;
        }
    }

    public void OnGUI()
    {
        string display;
        display = baseString + m_Score + " / " + m_ScoreNeeded;
        GUI.Label(ScorePosition, display);
    }
}
