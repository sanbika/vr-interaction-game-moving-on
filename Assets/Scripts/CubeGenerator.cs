using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeGenerator : MonoBehaviour
{
    public GameObject[] types;
    //points where the cube will be instantiated
    public Transform[] points;
    //the time interval to generate a cube(according to the bgm)
    public float beat;
    //count time to xontrol the update loop
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > beat)
        {
            //randomly generate color and points
            GameObject cube = Instantiate(types[Random.Range(0, 6)], points[Random.Range(0, 4)]);
            //make sure that cube is generated at the set point
            cube.transform.localPosition = Vector3.zero;
            //change cube randomly in four directions, up/down/left/right
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            //update timer
            timer -= beat;
        }
        // add once at each frame
        timer += Time.deltaTime;
    }
}
