using UnityEngine;
using System.Collections;

public class LightRotation : MonoBehaviour
{

    public float m_MoveSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(m_MoveSpeed * Time.deltaTime, 0.0f, 0.0f);
	}
}
