using UnityEngine;
using System.Collections;

public class CameraBeh : MonoBehaviour
{
    public GameObject m_ObjToFollow;
    public float m_RotationSpeed = 15;
    private Transform m_ObjTrans;
    //private Vector3 m_Offset;
    private Vector3 objLastFramePos;
    public void Init(GameObject _obj)
    {
        //what object the camera will follow
        m_ObjToFollow = _obj;
        m_ObjTrans = m_ObjToFollow.transform;
      //  m_Offset = transform.position - m_ObjTrans.position;
        //transform.position += m_ObjTrans.position + m_Offset;
        objLastFramePos = m_ObjTrans.position;
        
    }
    public void MoveCamera(float _xAmount, float _yAmount)
    {
        //how much to move the camera from last from to this frame
        Vector3 distanceTraveled = m_ObjTrans.position - objLastFramePos; 
        //look at the ball
        transform.LookAt(m_ObjTrans);
        //how much to rotate
        Vector3 rotationY = Vector3.left * _xAmount * m_RotationSpeed * Time.deltaTime;
        Vector3 rotationX = Vector3.up   * _yAmount * m_RotationSpeed * Time.deltaTime;
        //move the camera based off of rotation
        transform.Translate(rotationX);
        transform.Translate(rotationY);
        //move the camera based off of the distance between the ball
        transform.position += distanceTraveled;
        //update the last frame position
        objLastFramePos = m_ObjTrans.position;
    }
    

}
