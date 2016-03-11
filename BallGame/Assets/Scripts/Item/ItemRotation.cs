using UnityEngine;
using System.Collections;

public class ItemRotation : MonoBehaviour
{

    public float m_MoveSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0.0f, m_MoveSpeed * Time.deltaTime,  0.0f);	    
	}
}
