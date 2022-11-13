using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{


    private void Awake()
    {
       
    }

    private void Update()
    {
        transform.Rotate(0, 0, 10);
    }
}
