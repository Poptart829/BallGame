using UnityEngine;
using System.Collections;

public class CameraBeh : MonoBehaviour
{
    public GameObject m_ObjToFollow;
    public float m_RotationSpeed = 15;
    private Transform m_ObjTrans;
    private Vector3 m_Offset;
    private Vector3 objLastFramePos;
    private Vector3 returnToPosition;
    public GameObject m_SpawnPoint;
    public void Init(GameObject _obj)
    {
        //what object the camera will follow
        transform.position =  m_SpawnPoint.transform.position;
        m_ObjToFollow = _obj;
        m_ObjTrans = m_ObjToFollow.transform;
        m_Offset = transform.position - m_ObjTrans.position;
        objLastFramePos = m_ObjTrans.position;
        returnToPosition = Vector3.zero;
        Debug.Log("Camera FOV" + Camera.main.fieldOfView);

    }
    public void MoveCamera(float _xAmount, float _yAmount)
    {
        //how much to move the camera from last from to this frame
        Vector3 distanceTraveled = m_ObjTrans.position - objLastFramePos;
        //look at the ball
        transform.LookAt(m_ObjTrans);
        //how much to rotate
        Vector3 rotationY = Vector3.left * _xAmount * m_RotationSpeed * Time.deltaTime;
        Vector3 rotationX = Vector3.up * _yAmount * m_RotationSpeed * Time.deltaTime;
        //move the camera based off of rotation
        transform.Translate(rotationX);
        transform.Translate(rotationY);
        //move the camera based off of the distance between the ball
        transform.position += distanceTraveled;
        //update the last frame position
        objLastFramePos = m_ObjTrans.position;
    }
    private bool beenHit;
    Vector3 distanceBetween;
    Vector3 targetDistance;
    Vector3 lerpTo;
    Vector3 pos;
    Vector3 resetPos;
    void LateUpdate()
    {
        RaycastHit hit;
        LayerMask mask;
        mask = 1 << 8;
        mask = ~mask;
        Debug.DrawLine(transform.position, m_ObjTrans.position, Color.black);
#if true
        if (Physics.Linecast(transform.position, m_ObjTrans.position, out hit, mask))
        {
            if (!beenHit)
                pos = hit.transform.position;
            beenHit = true;
            transform.position = Vector3.Lerp(transform.position, m_ObjTrans.position, Time.deltaTime);

            Vector3 rotationY = Vector3.left * m_RotationSpeed * Time.deltaTime;
            //move the camera based off of rotation
            transform.Translate(rotationY);
        }
        if (beenHit)
        {
            distanceBetween = transform.position - m_ObjTrans.position;
            targetDistance = (pos - m_ObjTrans.position) - distanceBetween;
            lerpTo = transform.position + targetDistance;
            transform.position = Vector3.Lerp( lerpTo, transform.position, Time.deltaTime * 5.0f);
            if ((transform.position - lerpTo).magnitude < 0.1f)
                beenHit = false;
        }
#else
        if (Physics.Linecast(transform.position, m_ObjTrans.position, out hit, mask))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 10, Time.deltaTime * 2.0f);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime * 2.0f);
        }
#endif
    }
}
