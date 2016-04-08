using UnityEngine;
using System.Collections;

public class BallLives : MonoBehaviour
{
    private int m_Lives;
    private int m_StartLives;
	// Use this for initialization
	void Start ()
    {
        m_StartLives = m_Lives;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void Die()
    {
        m_Lives = m_StartLives;
    }

    public void IncLives(int _add)
    {
        m_Lives += _add;
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20),"Player Lives :  " + m_Lives.ToString());
    }

}
