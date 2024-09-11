using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour
{
   [SerializeField] int _id;
    void Update(){
        transform.position += new Vector3(0, -3, 0) * Time.deltaTime;
        if(transform.position.y <= -4){
            transform.position = new Vector3(0,5,0);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            if(player != null){

                if(_id == 0){player.AtivarTiroTriplo();}
                if(_id == 1){player.AtivarVelocidade();}
                if(_id == 2){player.AtivarEscudo();}
                Destroy(gameObject);
            }
        }
    }
}
