﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCoordinator : MonoBehaviour
{
    public GameObject m_InputManager;
    public GameObject m_PlayerSpawner;
    public int m_NumPlayers = -1;
    public bool isController = false;
    private CameraBeh m_CamBeh;
    private PlayerSpawner m_PlayerSpawnerBeh;
    private InputManager m_InputManagerBeh;
    private Ball m_User;
    // Use this for initialization
    private void Awake()
    {
        m_PlayerSpawnerBeh = m_PlayerSpawner.GetComponent<PlayerSpawner>();
        m_InputManagerBeh = m_InputManager.GetComponent<InputManager>();
        m_CamBeh = Camera.main.GetComponent<CameraBeh>();
        if (m_NumPlayers == -1)
            m_NumPlayers = 1;
    }
    void Start()
    {
        //used to read if we have controllers connected through unity interface
        string[] Connected = Input.GetJoystickNames();
        if (Connected.Length > 0)
            isController = true;
        //init basic info needed to spawn the players
        m_PlayerSpawnerBeh.InitPlayerInfo();
        //spawn the players
        m_PlayerSpawnerBeh.SpawnPlayers();
        //init the camera, along with what obj the camera will follow
        m_CamBeh.Init(m_PlayerSpawnerBeh.GetPlayer);
        //set the game type and controlls need to be distrubted to the players
        m_InputManagerBeh.InitGame(InputManager.GameType.BallGame);
        // if there is one player in the game, and he doesn't want to use the keyboard
        //bool SinglePlayerController = isController && m_NumPlayers == 1 ? true : false;
        //assign input to the players that are connected
        m_InputManagerBeh.AssignInput(m_PlayerSpawnerBeh, m_NumPlayers);
        //set the user
        m_User = m_PlayerSpawnerBeh.GetPlayer.GetComponent<Ball>();

    }

    // Update is called once per frame
    void Update()
    {
        //read each players input for the frame
        foreach (BallCtrl player in m_User.AttachedPlayers)
            player.ReadInput(m_InputManagerBeh);
        //hae the ballread all the input the players just made
        m_User.ReadPlayerInput();
        //move the ball based off of input
        m_User.Movement(m_User.m_Movement, m_User.m_Jumping);
        //reset all ball's values so its read for next frame
        m_User.ResetMovementValues();
    }
}
