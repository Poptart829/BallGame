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
    public float m_FinalCamHorizontal;
    public float m_FinalCamVertical;
    // Use this for initialization
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        ResetMovementValues();
    }

    public void ReadPlayerInput()
    {
        //reads all player input
        //for each player attached to the ball
        foreach (BallCtrl player in AttachedPlayers)
        {
            m_FinalHorizontal += player.Horizontal;
            m_FinalVertical += player.Vertical;
            m_FinalJump += player.m_Jump;
            m_FinalCamHorizontal += player.CamHorizontalValue;
            m_FinalCamVertical += player.CamVerticalValue;
        }
        m_Movement.x = m_FinalHorizontal;
        m_Movement.z = m_FinalVertical;
        //from unity ball project. dont get it but it seems to work.
        //m_Movement = (m_FinalVertical * Vector3.right + m_FinalHorizontal * Vector3.forward).normalized;
        m_Jumping = m_FinalJump > 0.0f ? true : false;
    }

    public void Movement(Vector3 moveDirection, bool jump, GameObject _camera)
    {
        if (moveDirection.magnitude <= 0.0f)
            return;

        Vector3 movement = new Vector3();
        movement = moveDirection.z * _camera.transform.forward + moveDirection.x * _camera.transform.right;

        //caps the movement speed
        float curSpeed = m_RigidBody.velocity.magnitude;
        if (curSpeed < m_MaxSpeed)
            m_RigidBody.AddForce(movement.normalized * m_MovePower * m_SpeedMultiplier);
        if (Physics.Raycast(transform.position, -Vector3.up / 2, k_GroundRayLength) && jump)
        {
            Vector3 jumpvec = Vector3.up * m_JumpPower;
            m_RigidBody.AddForce(jumpvec, ForceMode.Impulse);
        }

    }

    public void ResetMovementValues()
    {
        m_FinalHorizontal = m_FinalJump = m_FinalVertical =
            m_FinalCamVertical = m_FinalCamHorizontal = 0;
        m_Movement = Vector3.zero;
        m_Jumping = false;
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
    }
}
