using UnityEngine;
using System.Collections;

public class StarWall : MonoBehaviour
{
    public float m_UpTime = 1.4f;
    public float m_Speed = 5.0f;
    public Vector3 Direction;
    public bool StartMovement = true;
    // Update is called once per frame
    void Update()
    {
        if (m_UpTime > 0.0f && StartMovement)
        {
            MoveDown();
        }
    }

    public void MoveDown()
    {
        m_UpTime -= Time.deltaTime;
        transform.Translate(Direction * Time.deltaTime * m_Speed);
    }
}
