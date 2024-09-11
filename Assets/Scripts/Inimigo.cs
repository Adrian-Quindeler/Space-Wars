using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] GameObject explosao;
    // Update is called once per frame
    void Update(){
        transform.Translate(new Vector3(0,-3,0) * Time.deltaTime);
        if(transform.position.y < -7){
            int posX = Random.Range(-9, 9);
            transform.position = new Vector3(posX, 7, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Laser"){
            if(other.transform.parent != null){
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other);
            Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            if(player != null){
                player.Dano();
                Instantiate(explosao, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
