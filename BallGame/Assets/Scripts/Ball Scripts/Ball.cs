using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public BallCtrl[] AttachedPlayers;
    public bool m_Jumping;
    public Vector3 m_Movement;
    public float m_SpeedMultiplier = 1;
    public float m_JumpPower;
    public float m_MaxSpeed = 5;
    private float m_MovePower = 5;
    private float m_MaxAngularVelocity = 25.0f;
    private const float k_GroundRayLength = 1.0f;
    private Rigidbody m_RigidBody;
    private float m_FinalHorizontal;
    private float m_FinalVertical;
    private float m_FinalJump;
    // Use this for initialization
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        ResetMovementValues();
    }

    public void ReadPlayerInput()
    {
        foreach (BallCtrl player in AttachedPlayers)
        {
            m_FinalHorizontal += player.Horizontal;
            m_FinalVertical += player.Vertical;
            m_FinalJump += player.m_Jump;
        }
        m_Movement = (m_FinalVertical * Vector3.right + m_FinalHorizontal * Vector3.forward).normalized;
        m_Jumping = m_FinalJump > 0.0f ? true : false;
    }

    public void Movement(Vector3 moveDirection, bool jump)
    {
        float curSpeed = m_RigidBody.velocity.magnitude;
        if (curSpeed < m_MaxSpeed)
            m_RigidBody.AddForce(moveDirection * m_MovePower * m_SpeedMultiplier);
        if (Physics.Raycast(transform.position, -Vector3.up / 2, k_GroundRayLength) && jump)
        {
            Vector3 jumpvec = Vector3.up * m_JumpPower;
            m_RigidBody.AddForce(jumpvec, ForceMode.Impulse);
        }

    }

    public void ResetMovementValues()
    {
        m_FinalHorizontal = m_FinalJump = m_FinalVertical = 0;
        m_Movement = Vector3.zero;
        m_Jumping = false;
    }
}
