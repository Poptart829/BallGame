using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour
{
    private StarWall wallScript;
    // Use this for initialization
    private bool start = false;
    void Start()
    {
        wallScript = gameObject.GetComponent<StarWall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wallScript.StartMovement == true)
            return;
        Collider[] hit = Physics.OverlapBox(transform.position - new Vector3(0, 2, 2), new Vector3(15, 3, 6));
        foreach (Collider col in hit)
        {
            if (col.gameObject.tag == "Player")
                start = true;
        }
        if (start)
            wallScript.StartMovement = true;
    }
}
