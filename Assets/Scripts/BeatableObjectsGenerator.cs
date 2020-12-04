using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BeatableObjectsGenerator : MonoBehaviour
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
    //count time to control the update loop
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
            if(probability < 8)
            {
                GameObject cube = Instantiate(dirCubeTypes[Random.Range(0, 6)], dirCubePoints[Random.Range(0, 4)]);
                //make sure that cube is generated at the set point
                cube.transform.localPosition = Vector3.zero;
                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
                /* GameObject obastacle = Instantiate(obstaclesTypes[Random.Range(0, 1)], obstaclePoints[Random.Range(0, 2)]);
                 obastacle.transform.localPosition = Vector3.zero;*/
            }
            else if( probability == 8)
            {
                GameObject obastacle = Instantiate(obstaclesTypes[Random.Range(0, 1)], obstaclePoints[Random.Range(0, 2)]);
                obastacle.transform.localPosition = Vector3.zero;
            }
            else
            {
                GameObject prop = Instantiate(propsTypes[Random.Range(0, 1)], dirCubePoints[Random.Range(0, 4)]);
                prop.transform.localPosition = Vector3.zero;
            }

            //update timer
            timer -= beat;
        }
        // add once at each frame
        timer += Time.deltaTime;
    }
}
