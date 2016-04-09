using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour
{
    private StarWall wallScript;
    // Use this for initialization
    void Start()
    {
        wallScript = gameObject.GetComponent<StarWall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wallScript.StartMovement == true)
            return;
    }

    public StarWall GetWall()
    {
        return wallScript;
    }
}
