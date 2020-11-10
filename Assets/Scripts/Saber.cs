using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Saber : MonoBehaviour
{
  
    public LayerMask layer;
    public string saberColor;
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
        //length of ray
        float distance = 1.1f;

        //(to be deleted!)see the ray in game to do adjustment
        //Debug.DrawRay(transform.position, transform.forward * distance);

        if (Physics.Raycast(hitRay, out hit, distance, layer))
        {
            //check with bomb first, then color, then direction
            var cube = hit.collider.gameObject.GetComponent<CubeBehavior>();
            var cubeObj = hit.collider.gameObject;
            //??????????????Difference between collider and transform?????

            if (cube.isBomb)
            {
                //TODO points decrease
                //TODO false effect
            }
            else
            {
                if (cube.color != this.saberColor)
                {
                    //TODO points decrease
                    //TODO false effect
                }
                else
                {
                    if (cube.directionType == "no")
                    {
                        Destroy(cubeObj);
                    }

                    else if (cube.directionType == "single")
                    {
                        //to check if the cut direction right
                        if (Vector3.Angle(transform.position - previousPosition, hit.transform.up) > 130)
                        {
                            Destroy(cubeObj);
                        }

                    }
                }

            }
        }
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
 * The first method is to create appropriate layer for them:
 *      1. color 
 *      2. direction
 * If I use color layer to distinguish them, there are 3 types:
 *      1. green
 *      2. gray
 *      3. white(double dir)
 *    all above should be able to interact with sabers, so they should form a layerMask(betable).
 *    
 *    But then there is a problem. Since each object only has one layer. Both single dir and no dir have the same layer.(e.g. green)
 *    
 *    If I need to distinguish them, I need to add a new attribute for all cubes called 'directionType'. It can be used to justify whether 
 *    it is single dir or no dir or double dir.
 *    
 *    But this method has a drawback, it is complicated to understand, to bind with related type of saber, a layer should be set in Unity
 *    on the saber, then the progress to create layerMask should involved in variable(layer). 
 *    
 * If I use direction layer, there are also 3 types:
 *      1. no
 *      2. single
 *      3. double
 * No need to transfer in layer Variable but need to add color attribute to cube, create betable layerMask, and check with color attribute
*/