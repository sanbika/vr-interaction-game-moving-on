using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeGenerator : MonoBehaviour
{
    //for betable direction cube
    public GameObject[] dirCubeTypes;
    public Transform[] dirCubePoints;
    //for obstacles
    public GameObject[] obstaclesTypes;
    public Transform[] obstaclePoints;
    //for props
    public GameObject[] propsTypes;

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
            var probability = Random.Range(0, 10);
            if(probability < 6)
            {
                //randomly generate color and points
                GameObject cube = Instantiate(dirCubeTypes[Random.Range(0, 6)], dirCubePoints[Random.Range(0, 4)]);
                //make sure that cube is generated at the set point
                cube.transform.localPosition = Vector3.zero;
                //change cube randomly in four directions, up/down/left/right
                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            }
            else if( 6<= probability && probability < 8)
            {
                GameObject obastacle = Instantiate(obstaclesTypes[Random.Range(0, 1)], obstaclePoints[Random.Range(0, 2)]);
                obastacle.transform.localPosition = Vector3.zero;
            }
            else
            {
                GameObject prop = Instantiate(obstaclesTypes[Random.Range(0, 1)], dirCubePoints[Random.Range(0, 4)]);
                prop.transform.localPosition = Vector3.zero;
            }

            //update timer
            timer -= beat;
        }
        // add once at each frame
        timer += Time.deltaTime;
    }
}
