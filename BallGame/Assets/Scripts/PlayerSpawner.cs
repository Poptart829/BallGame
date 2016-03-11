using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject m_PlayerPrefabs;
    public GameObject m_SpawnPos;
    private GameObject m_CurrentPlayer;
    public ObjInfo info;
    private GameObject m_Player;
    public GameObject GetPlayer
    {
        get { return m_Player; }
    }
    public struct ObjInfo
    {
        GameObject m_Obj;
        Vector3 m_SPos;
        public GameObject PlayerObj
        {
            get { return m_Obj; }
            set { m_Obj = value; }
        }
        public Vector3 SpawnPos
        {
            get { return m_SPos; }
            set { m_SPos = value; }
        }
    }
    public void InitPlayerInfo()
    {
        info = new ObjInfo();
        info.PlayerObj = m_PlayerPrefabs;
        info.SpawnPos = m_SpawnPos.transform.position;

    }
    public void Activate(bool _b)
    {
        gameObject.SetActive(_b);
    }

    public void SpawnPlayers()
    {
        //spawn the player
        m_Player = Instantiate(info.PlayerObj, info.SpawnPos, Quaternion.identity) as GameObject;
        m_Player.transform.Rotate(Vector3.up, -90.0f);
    }
}
