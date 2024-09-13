using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _inimigo;
    [SerializeField] GameObject[]  _powerUps = new GameObject[3];
    float _velocidadeDeSpawnInimigo = 5;

    void Start()
    {
        StartCoroutine(InstanciarInimigo());
    }

    IEnumerator InstanciarInimigo(){
        while(true){
            Instantiate(_inimigo, new Vector3(Random.Range(-9.0f, 9.1f), 10, 0), Quaternion.identity);
            yield return new WaitForSeconds(_velocidadeDeSpawnInimigo);
        }
    }

    IEnumerator InstanciarPowerUp(){
        while(true){
            Instantiate(_powerUps[Random.Range(0,3)], new Vector3(Random.Range(-9, 9), 10, 0), Quaternion.identity);
            yield return new WaitForSeconds(_velocidadeDeSpawnInimigo);
        }
    }
}
