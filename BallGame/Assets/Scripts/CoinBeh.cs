using UnityEngine;
using System.Collections;

public class CoinBeh : MonoBehaviour
{
    public int m_Worth = 1;
    private AudioSource m_HitSound;
    // Use this for initialization
    void Start()
    {
        m_HitSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider _hit)
    {
        if (_hit.gameObject.tag == "Player")
        {
            BallScore score = _hit.gameObject.GetComponent<BallScore>();
            score.IncScore(m_Worth);
            m_HitSound.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject,m_HitSound.clip.length);
        }
    }
}
