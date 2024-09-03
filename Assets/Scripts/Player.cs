using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _velocidade = 7;
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject _tiroTriploPrefab;
    [SerializeField] bool _tiroTriplo;
    float _cadencia = 0.4f;
    float _ultimoTiro = 0;

    void Start(){
        transform.position = new Vector3(0, -3, 0);
    }
    void Update(){
        Limites();
        Movimentar();
        if(Input.GetKey(KeyCode.Space) | Input.GetMouseButton(0)){
            Atirar();
        }
    }
    void Movimentar(){
        transform.Translate(new Vector3(1, 0, 0) * _velocidade * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        transform.Translate(new Vector3(0, 1, 0) * _velocidade * Time.deltaTime * Input.GetAxisRaw("Vertical"));
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
        if(transform.position.x > 9.6){
            transform.position = new Vector3(-9.6f, transform.position.y, 0);
        }
        else if(transform.position.x < -9.6){
            transform.position = new Vector3(9.6f, transform.position.y, 0);
        }
    }

    void Atirar(){
        if(_ultimoTiro <= Time.time){
            if(_tiroTriplo){
                Instantiate(_tiroTriploPrefab, transform.position, Quaternion.identity);
            }
            else{
                Instantiate(_prefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            }
            _ultimoTiro = Time.time + _cadencia;
        }
    }
}
