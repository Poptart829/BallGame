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
    //used if m_Controls reads CamVertical Movement
    public float CamVerticalValue;
    //used if m_Control reads CamHorizontal movement
    public float CamHorizontalValue;

    public string m_HorizontalAxisName;
    public string m_VerticalAxisName;
    public string m_JumpAxisName;
    public string m_CamHorizontalAxisName;
    public string m_CamVerticalAxisName;

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
                case InputManager.InputControlsBall.CamHorizontalAxis:
                    CamHorizontalValue = _InputManager.ReadInput(m_Controls[x], m_CamHorizontalAxisName);
                    break;
                case InputManager.InputControlsBall.CamVerticalAxis:
                    CamVerticalValue = _InputManager.ReadInput(m_Controls[x], m_CamVerticalAxisName);
                    break;
            }
        }
    }
    private void SPCXBOX(InputManager.InputControlsBall _input)
    {
        switch (_input)
        {
            case InputManager.InputControlsBall.HorizontalAxis:
                m_HorizontalAxisName = "SHorizontal";
                break;
            case InputManager.InputControlsBall.VerticalAxis:
                m_VerticalAxisName = "SVertical";
                break;
            case InputManager.InputControlsBall.Jump:
                m_JumpAxisName = "SJump";
                break;
            case InputManager.InputControlsBall.CamHorizontalAxis:
                m_CamHorizontalAxisName = "SCamHorizontal";
                break;
            case InputManager.InputControlsBall.CamVerticalAxis:
                m_CamVerticalAxisName = "SCamVertical";
                break;
        }
    }

    private void SPCKEYBOARD(InputManager.InputControlsBall _input, int _player)
    {
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
            case InputManager.InputControlsBall.CamHorizontalAxis:
                m_CamHorizontalAxisName = "CamHorizontal " + _player;
                break;
            case InputManager.InputControlsBall.CamVerticalAxis:
                m_CamVerticalAxisName = "CamVertical " + _player;
                break;
        }
    }

    private void DOUBLEXBOX(InputManager.InputControlsBall _input, bool _player)
    {
        switch (_input)
        {
            case InputManager.InputControlsBall.HorizontalAxis:
                if (_player )
                    m_HorizontalAxisName = "Horizontal 1";
                else
                    m_HorizontalAxisName = "SHorizontal";
                break;
            case InputManager.InputControlsBall.VerticalAxis:
                if (_player)
                    m_VerticalAxisName = "Vertical 1";
                else
                    m_VerticalAxisName = "SVertical";
                break;
            case InputManager.InputControlsBall.Jump:
                if (_player)
                    m_JumpAxisName = "Jump 1";
                else
                    m_JumpAxisName = "SJump";
                break;
            case InputManager.InputControlsBall.CamHorizontalAxis:
                if (_player)
                    m_CamHorizontalAxisName = "CamHorizontal 1"; 
                else
                    m_CamHorizontalAxisName = "SCamHorizontal";
                break;
            case InputManager.InputControlsBall.CamVerticalAxis:
                if (_player)
                    m_CamVerticalAxisName = "CamVertical 1";
                else
                    m_CamVerticalAxisName = "SCamVertical";
                break;
        }
    }

    public void SetNames(InputManager.InputControlsBall _input, int _player, bool _singlePlayerController, InfoPasser.Controls _controls)
    {
        // set the solo player
        // if ther is one pass the bool

        switch (_controls)
        {
            case InfoPasser.Controls.OneKeyboard:
                Debug.Log("SWITCH ONE KEY BOARD");
                SPCKEYBOARD(_input, _player);
                break;
            case InfoPasser.Controls.OneXbox:
                Debug.Log("ONE XBOX CONTROLLER");
                SPCXBOX(_input);
                break;
            case InfoPasser.Controls.KeyboardAndXbox:
                Debug.Log("ONE KEYBOARD & ONE XBOX CONTROLLER");
                SPCXBOX(_input); break;
            case InfoPasser.Controls.DoubleXbox:
                Debug.Log("TWO XBOX CONTROLLERS");
                bool temp = _player == 1 ? true : false;
                DOUBLEXBOX(_input, temp);
                break;
            default:
                break;
        }
    }
}
