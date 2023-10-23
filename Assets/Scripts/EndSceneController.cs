using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void LateUpdate()
    //after all calculation is finished in update
    {
        if (!player)
        {
            return;
            
        }


        tempPos = transform.position;//current pos of camera
        tempPos.x = player.position.x;
        transform.position = tempPos;

    }
}
