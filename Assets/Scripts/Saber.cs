using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    //the layer of the cube that is going to be cut
    public LayerMask layer;
    private Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray stores position and direction info
        Ray hitRay = new Ray(transform.position, transform.forward);
        //RaycastHit stores the info on the colliders hit(to find out which objects are intersected by the ray)
        RaycastHit hit;
        //legnth of ray
        float distance = 1.1f;

        //(to be deleted!)see the ray in game to do adjustment
        //Debug.DrawRay(transform.position, transform.forward * distance);

        var betableObjectMask = LayerMask.GetMask("bombCubes", "doubleDirCubes",
                                                    "greenCubes", "grayCubes");
        var bothColorMask = LayerMask.GetMask("greenCubes", "grayCubes", "doubleDirCubes");

        Debug.Log(betableObjectMask);

        if (Physics.Raycast(hitRay, out hit, distance, betableObjectMask))

        //below is the previous code
/*        if (Physics.Raycast(hitRay, out hit, distance, layer))
        {
            //to check if the cut direction right
            if (Vector3.Angle(transform.position - previousPosition, hit.transform.up) > 110)
            {
                Destroy(hit.transform.gameObject);
            }
        }*/

        previousPosition = transform.position;
        
    }
}

//gameObject.layer是获得对应layer的数字
//LayerMask.NameToLayer(“LayerName”); 会return这个layer对应的数字

//两种对应的做法
//gameObject.layer = LayerMask.NameToLayer("Green Cubes");
//LayerMask.LayerToName(gameObject.layer);

//来获得对应的两个layer的index
//var mask = LayerMask.GetMask("Player","Enemy")

//generating layer mask
//var greenCubeLayerMask = 1<<GreenCube.layer;

//combining layer masks
//take a example of layer 4&5
//var layerMask = (1<<4)|(1<<5);


/*
 * There are total 5 types of cubes.
 *     single dir - green/gray
 *     no dir - green/gray
 *     double dir - both
 * The first problem is to create appropriate layer for them:
 *      1. color 
*/