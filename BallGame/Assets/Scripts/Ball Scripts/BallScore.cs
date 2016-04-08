using UnityEngine;
using System.Collections;

public class BallScore : MonoBehaviour
{
    private int m_Score = 0;
    private string baseString;
    private Rect ScorePosition = new Rect(10, 30, 200, 20);

	// Use this for initialization
	void Start ()
    {
        baseString = "Player Score : ";
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void IncScore(int _amount)
    {
        m_Score += _amount;
    }

    public void OnGUI()
    {
        GUI.Label(ScorePosition, baseString + m_Score);
    }
}
