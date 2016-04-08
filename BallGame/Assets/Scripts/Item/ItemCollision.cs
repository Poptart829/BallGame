using UnityEngine;
using System.Collections;

public class ItemCollision : MonoBehaviour
{
    public ItemDefs.ItemTypes m_ItemType;
    public void OnCollisionEnter(Collision _hit)
    {
        if (_hit.gameObject.tag.CompareTo("Player") == 0)
        {
            switch (m_ItemType)
            {
                case ItemDefs.ItemTypes.SPEED:
                    Ball b = _hit.gameObject.GetComponent<Ball>();
                    if (b)
                    {
                        b.m_SpeedMultiplier++;
                        b.m_MaxSpeed += 2.0f;
                    }
                    break;
                case ItemDefs.ItemTypes.LIVES:
                    BallLives bLives = _hit.gameObject.GetComponent<BallLives>();
                    if (bLives)
                        bLives.IncLives(1);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
