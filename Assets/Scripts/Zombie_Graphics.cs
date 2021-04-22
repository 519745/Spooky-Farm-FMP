using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Zombie_Graphics : MonoBehaviour
{
    public AIPath aiPath;

    private float waitToReload;
    private bool reloading;
    private GameObject thePlayer;


    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-0.4308391f, 0.4308391f, 0.8616782f);
        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(0.4308391f, 0.4308391f, 0.8616782f);
        }
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload <0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;

        }
    }
}

