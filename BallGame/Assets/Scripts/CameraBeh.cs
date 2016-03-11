using UnityEngine;
using System.Collections;

public class CameraBeh : MonoBehaviour
{
    public GameObject m_ObjToFollow;
    private Transform m_ObjTrans;
    private Vector3 m_Offset;
    public void Init(GameObject _obj)
    {
        //what object the camera will follow
        m_ObjToFollow = _obj;
        m_ObjTrans = m_ObjToFollow.transform;
        m_Offset = transform.position - m_ObjTrans.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
#if true
       
        transform.position = m_ObjTrans.position + m_Offset;
        transform.LookAt(m_ObjTrans);
#else
        float damping = 1.0f;
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = m_ObjTrans.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);

        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = m_ObjTrans.position - (rotation * m_Offset);

#endif
    }
    
    

}
