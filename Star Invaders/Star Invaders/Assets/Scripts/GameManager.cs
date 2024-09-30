using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player _player;
    UIManager _uiManager;
    SpawnManager _spawnManager;
    public bool isGameOver;
    [SerializeField] GameObject _playerPrefab;

    void Start(){
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _player = _playerPrefab.GetComponent<Player>();
        isGameOver = true;
    }

    void Update(){
        if(isGameOver & Input.GetKey(KeyCode.Space)){
            Iniciarjogo();
        }
    }

    private void Iniciarjogo(){
        isGameOver = false;
        _uiManager.RemoverTitulo();
        Instantiate(_player, new Vector3(0, -4, 0), Quaternion.identity);
        StartCoroutine(_spawnManager.InstanciarInimigo());
        StartCoroutine(_spawnManager.InstanciarPowerUp());
    }

    public void TerminarJogo(){
        isGameOver = true;
        _uiManager.AtivarTitulo();
    }
}
