using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    void Update(){
        transform.position += new Vector3(0, -3, 0) * Time.deltaTime;
        if(transform.position.y <= -4){
            transform.position = new Vector3(0,5,0);
        }
    }
}
