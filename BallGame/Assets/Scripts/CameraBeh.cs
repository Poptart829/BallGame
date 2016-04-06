using UnityEngine;
using System.Collections;

public class CameraBeh : MonoBehaviour
{
    private GameObject m_ObjToFollow;
    public float m_RotationSpeed = 7;
    private Transform m_ObjTrans;
    private Vector3 objLastFramePos;
    public GameObject m_SpawnPoint;
    private float m_Magnitude = 4.0f;
    private float m_SphereRadius = 1.0f;
    private Vector3 snapShotPosition;

    public void Init(GameObject _obj)
    {
        //what object the camera will follow
        transform.position = m_SpawnPoint.transform.position;
        m_ObjToFollow = _obj;
        m_ObjTrans = m_ObjToFollow.transform;
        objLastFramePos = m_ObjTrans.position;
        transform.position = m_ObjTrans.position + (transform.position - m_ObjTrans.position);
    }

    private bool getBack = false;
    public void MoveCamera(float _xAmount, float _yAmount)
    {
        float currentMagnitude = (m_ObjTrans.position - transform.position).magnitude;
        if (currentMagnitude < m_Magnitude)
        {
            if (!getBack)
                snapShotPosition = transform.position;
            getBack = true;
        }
        if (BackUp(currentMagnitude, ref getBack, snapShotPosition))
            _xAmount = _yAmount = 0;
        //how much to move the camera from last from to this frame
        Vector3 distanceTraveled = m_ObjTrans.position - objLastFramePos;

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
        //look at the ball

        transform.LookAt(m_ObjTrans);
        CameraLineCheck();
    }

    bool BackUp(float _currentMagnitude, ref bool _getBack, Vector3 snapShotPos)
    {
        if (_currentMagnitude < m_Magnitude)
        {
            if (_getBack)
            {
                transform.position = snapShotPos;
                return _getBack;
            }
        }
        _getBack = false;
        return _getBack;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_SphereRadius);
    }

    private void CameraLineCheck()
    {
        RaycastHit hit;
        LayerMask mask;
        mask = ~(1 << 8);
        //Debug.DrawLine(transform.position, m_ObjTrans.position, Color.black);
        if (Physics.Linecast(transform.position, m_ObjTrans.position, out hit, mask))
        {
            this.transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    }
}
