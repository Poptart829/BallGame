using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    public enum InputControlsBall
    {
        HorizontalAxis, VerticalAxis,
        Jump,CamHorizontalAxis, CamVerticalAxis,
        MaxSize
    };

    public enum GameType
    {
        BallGame, CarGame
    };

    public GameType m_GameType;
    private Dictionary<InputControlsBall, float> m_InputLegend;
    // Use this for initialization
    public void InitGame(GameType _type)
    {
        //set up the controls need for the game type
        // SIDENOTE : in future will probly use different input manager per game, maybe
        if (_type == GameType.BallGame)
        {
            m_InputLegend = new Dictionary<InputControlsBall, float>();
            m_InputLegend.Add(InputControlsBall.HorizontalAxis, 0);
            m_InputLegend.Add(InputControlsBall.VerticalAxis, 0);
            m_InputLegend.Add(InputControlsBall.Jump, -1);
        }

        m_GameType = _type;
    }
    //public float ReadInput(InputControlsBall _input)
    //{
    //    return m_InputLegend[_input];
    //}

    public float ReadInput(InputControlsBall _input, string _name, bool jump = false)
    {
        float value = 0.0f;
        if (!jump)
        {
            value = Input.GetAxisRaw(_name);
            m_InputLegend[_input] = value;
        }
        else
        {
            value = Input.GetButton(_name) ? 1.0f : 0.0f;
            m_InputLegend[InputControlsBall.Jump] = value;
        }
        return value;
    }

    public float InputLookUp(InputManager.InputControlsBall _Input)
    {
        return m_InputLegend[_Input];
    }

    public void AssignInput(PlayerSpawner _pSpawn, int _numPlayers, bool _singlePlayerController, InfoPasser.Controls _controls)
    {
        if (_pSpawn.GetPlayer == null)
        {
            Debug.Log("NULL PLAYER");
            return;
        }
        GameObject user = _pSpawn.GetPlayer;
        Ball ball = user.GetComponent<Ball>();
        ball.AttachedPlayers = new BallCtrl[_numPlayers];
        for (int x = 0; x < _numPlayers; x++)
        {
            GameObject obj = new GameObject("Player " + x);
            obj.transform.SetParent(user.transform);
            obj.AddComponent<BallCtrl>();
        }
        //current player we are assigning input too
        int curPlayer = 0;
        //number of players on the ball
        int size = user.transform.childCount;
        //looping through all the input/controls we need to assign to the players on the ball
        for (int x = 0; x < (int)InputControlsBall.MaxSize; x++)
        {
            //get the transform so we can get the gameobj
            Transform t = user.transform.GetChild(curPlayer);
            //get the ballctrl on the child transform/gameobj
            BallCtrl b = t.gameObject.GetComponentInChildren<BallCtrl>();
            //the player arry in the ball, assign a ballctrl to it
            ball.AttachedPlayers[curPlayer] = b;
            //error checking
            if (b == null)
            {
                Debug.Log("ASSIGN INPUT B IS NULL");
                return;
            }
            //add the input that the player will be responceable for 
            b.m_Controls.Add((InputControlsBall)x);
            //set names for unity to read input
            b.SetNames((InputControlsBall)x, curPlayer, _singlePlayerController,_controls);
            //we need to make sure the current player never excides
            if (curPlayer + 1 >= size)
                curPlayer = 0;
            else
                curPlayer++;
        }
    }
}
