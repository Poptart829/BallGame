using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour
{
    public GameObject m_CoinPrefab;
    public GameObject m_MapPrefab;
    private int m_Offset = 5;
    private GameObject m_FirstBorn ;
    private int m_Amount;
    public int m_ClearAmount;
    // Use this for initialization
    void Start()
    {
        m_FirstBorn = new GameObject("EmptyCoinHolder");
        Renderer r = m_MapPrefab.GetComponent<Renderer>();
        Vector3 size = r.bounds.size;
        for (int x = 0; x < size.x; x += m_Offset)
        {
            for (int z = 0; z < size.z; z += m_Offset)
            {
                GameObject obj = Instantiate(m_CoinPrefab, new Vector3(x, 1.0f, z), Quaternion.identity) as GameObject;
                Collider[] _col = Physics.OverlapSphere(obj.transform.position, 1.0f);
                bool hitWall = false;
                foreach (Collider c in _col)
                {
                    if (c.gameObject.tag == "Maze")
                        hitWall = true;
                }
                if (hitWall)
                    Destroy(obj);
                else
                {
                    m_Amount++;
                    obj.transform.SetParent(m_FirstBorn.transform);
                }
            }
        }

        m_ClearAmount = (m_Amount * 2) / 3;
    }

    public void DecCoinsLeft(int _sub)
    {
        m_Amount -= _sub;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(200, 10, 50, 50), "Coins Left : " + m_Amount.ToString());
    }

    public bool isDone(int _amount)
    {
        return _amount >= m_ClearAmount ? true : false;
    }

}
