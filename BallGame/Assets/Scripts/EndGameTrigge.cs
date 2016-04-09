using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGameTrigge : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("_End");
        }
    }
}
