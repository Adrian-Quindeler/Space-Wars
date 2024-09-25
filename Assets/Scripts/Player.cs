using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool _tiroTriplo;
    [SerializeField] float _velocidade = 6;
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject _escudo;
    [SerializeField] GameObject _explosao_prefab;
    [SerializeField] GameObject _tiroTriploPrefab;

    int _vida = 3;
    float _cadencia = 0.4f;
    int _duracaoEscudo = 0;
    float _ultimoTiro = 0;

    UIManager _uiManager;
    GameManager _gameManager;
    AudioSource _audioSource;

    void Start(){
        transform.position = new Vector3(0, -3, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(_uiManager != null){
            _uiManager.AtualizarVidas(_vida);
        }
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update(){
        Limites();
        Movimentar();
        if(Input.GetKey(KeyCode.Space) | Input.GetMouseButton(0)){
            Atirar();
        }
    }

    void Movimentar(){
        transform.Translate(new Vector3(1, 0, 0) * _velocidade * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        transform.Translate(new Vector3(0, 1, 0) * _velocidade * Input.GetAxisRaw("Vertical")   * Time.deltaTime);
    }
    void Limites(){
        if(transform.position.y >= 0){
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if(transform.position.y <= -4){
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        if(transform.position.x >= 9.6){
            transform.position = new Vector3(-9.6f, transform.position.y, 0);
        }
        else if(transform.position.x <= -9.6){
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
            _audioSource.Play();
            _ultimoTiro = Time.time + _cadencia;
        }
    }

    public void Dano(){
        if(_duracaoEscudo > 0){
            _duracaoEscudo--;
        }
        else{
            _vida--;
            _uiManager.AtualizarVidas(_vida);
            if(_vida <= 0){
                Instantiate(_explosao_prefab, transform.position, Quaternion.identity);
                _gameManager.TerminarJogo();
                Destroy(gameObject);
            }
        }

        if(_duracaoEscudo == 0){
            _escudo.SetActive(false);
        }
    }

#region TiroTriplo   
    public void AtivarTiroTriplo(){
        _tiroTriplo = true;
        StartCoroutine(DesativarTiroTriplo());
    }

    IEnumerator DesativarTiroTriplo(){

        yield return new WaitForSeconds(10);
        _tiroTriplo = false;
    }
#endregion

#region Velocidade
    public void AtivarVelocidade(){
        if(_velocidade == 6){_velocidade = 12;}
        else{_velocidade += 4;}

        if(_cadencia > 0.16f){_cadencia -= 0.15f;}
        StartCoroutine(DesativarVelocidade());
    }
    
    IEnumerator DesativarVelocidade(){
        yield return new WaitForSeconds(10);
        _velocidade = 6;
        _cadencia = 0.4f;
    }
#endregion

#region Escudo
    public void AtivarEscudo(){
        if(_duracaoEscudo <= 0){
            _duracaoEscudo = 2;
            _escudo.SetActive(true);
        }
        else{_duracaoEscudo++;}

    }
#endregion
}