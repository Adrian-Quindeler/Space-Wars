using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed = 5;
    public GameObject prefab;

    void Start(){
        transform.position = new Vector3(0, -3, 0);
    }
    void Update(){
        Movimentar();
        Limites();
        Atirar();
    }
    void Movimentar(){
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime * Input.GetAxisRaw("Vertical"));
    }
    void Limites(){
        //Limites da posição y: de 0 à -4
        if(transform.position.y >= 0){
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if(transform.position.y <= -4){
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        //Limites da posição x: de -9.5 à 9.5
        if(transform.position.x > 9.5){
            transform.position = new Vector3((float)-9.5, transform.position.y, 0);
        }
        else if(transform.position.x < -9.5){
            transform.position = new Vector3((float)9.5, transform.position.y, 0);
        }
    }

    void Atirar(){
        if(Input.GetKeyDown(KeyCode.Space) | Input.GetMouseButtonDown(0)){
            Instantiate(prefab, transform.position + new Vector3(0, (float)0.25, 0), Quaternion.identity);
        }
    }
}
