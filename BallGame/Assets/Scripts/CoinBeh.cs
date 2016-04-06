using UnityEngine;
using System.Collections;

public class CoinBeh : MonoBehaviour
{
    public int m_Worth = 1;
    private AudioSource m_HitSound;
    private ParticleSystem StarParticles;
    private float maxTime;
    private bool isDead = false;
    // Use this for initialization
    void Start()
    {
        m_HitSound = GetComponent<AudioSource>();
        StarParticles = GetComponentInChildren<ParticleSystem>();
        maxTime = StarParticles.duration > m_HitSound.clip.length ? StarParticles.duration : m_HitSound.clip.length;
    }

    void Update()
    {
        if(isDead)
        {
            maxTime -= Time.deltaTime;
            if(maxTime < 0.0f)
            {
                Destroy(StarParticles);
                Destroy(gameObject);
            }
        }
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
            //StarParticles.transform.SetParent(null);
            StarParticles.Play();
            isDead = true;
            //Destroy(StarParticles, StarParticles.duration);
            //Destroy(gameObject,m_HitSound.clip.length);
        }
    }
}
