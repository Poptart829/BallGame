using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallCtrl : MonoBehaviour
{
    public List<InputManager.InputControlsBall> m_Controls;

    //used if the m_Controls reads jump
    public float m_Jump;
    //used if m_Controls reads Horizontal
    public float Horizontal;
    //used if m_Controls reads Vertical
    public float Vertical;

    public string m_HorizontalAxisName;
    public string m_VerticalAxisName;
    public string m_JumpAxisName;

    private void Awake()
    {
        m_Controls = new List<InputManager.InputControlsBall>();
    }

    public void ReadInput(InputManager _InputManager)
    {
        int size = m_Controls.Count;
        for (int x = 0; x < size; x++)
        {
            switch (m_Controls[x])
            {
                case InputManager.InputControlsBall.HorizontalAxis:
                    Horizontal = _InputManager.ReadInput(m_Controls[x], m_HorizontalAxisName);
                    break;
                case InputManager.InputControlsBall.VerticalAxis:
                    Vertical = _InputManager.ReadInput(m_Controls[x], m_VerticalAxisName);
                    break;
                case InputManager.InputControlsBall.Jump:
                    m_Jump = _InputManager.ReadInput(m_Controls[x], m_JumpAxisName, true);
                    break;
            }
        }
    }

    public void SetNames(InputManager.InputControlsBall _input, int _player)
    {
        // set the solo player
        // if ther is one pass the bool
        switch (_input)
        {
            case InputManager.InputControlsBall.HorizontalAxis:
                m_HorizontalAxisName = "Horizontal " + _player;
                break;
            case InputManager.InputControlsBall.VerticalAxis:
                m_VerticalAxisName = "Vertical " + _player;
                break;
            case InputManager.InputControlsBall.Jump:
                m_JumpAxisName = "Jump " + _player;
                break;
        }
    }
}
