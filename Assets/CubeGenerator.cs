using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeGenerator : MonoBehaviour
{
    public GameObject[] cubes;
    //points where the cube will be instantiated
    public Transform[] points;
    //the time interval to generate a cube(according to the bgm)
    public float beat;
    //the remain
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
            //randomly generate color and directions
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            //make cube generated do not move
            cube.transform.localPosition = Vector3.zero;
            //change cube randomly in four directions, up/down/left/right
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            //update timer
            timer -= beat;
        }

        timer += Time.deltaTime;
    }
}
