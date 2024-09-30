using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void Update(){
        transform.position += new Vector3(0,20,0) * Time.deltaTime;
        if(transform.position.y >= 6){
            if(transform.parent != null){
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
