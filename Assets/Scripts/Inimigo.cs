using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] GameObject explosao;
    UIManager uiManager;

    void Start(){
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update(){
        transform.Translate(new Vector3(0,-3,0) * Time.deltaTime);
        if(transform.position.y < -7){
            float posX = Random.Range(-9.0f, 9.1f);
            transform.position = new Vector3(posX, 7, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Laser"){
            if(other.transform.parent != null){Destroy(other.transform.parent.gameObject);}
            Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            uiManager.AtualizarPontuação();
            Destroy(gameObject);
        }
        else if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            if(player != null){
                player.Dano();
                Instantiate(explosao, transform.position, Quaternion.identity);
                uiManager.AtualizarPontuação();
                Destroy(gameObject);
            }
        }
    }
}
