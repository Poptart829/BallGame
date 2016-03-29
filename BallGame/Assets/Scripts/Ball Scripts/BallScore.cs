using UnityEngine;
using System.Collections;

public class BallScore : MonoBehaviour
{
    private int m_Score = 0;

	// Use this for initialization
	void Start ()
    {
	
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
        GUI.Label(new Rect(10, 30, 200, 20), "Player Score : " + m_Score.ToString());
    }
}
