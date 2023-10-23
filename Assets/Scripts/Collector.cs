using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private Rigidbody2D gameObject;
    private void Start()
    {
        gameObject = GetComponent<Rigidbody2D>();
    }
    
}
