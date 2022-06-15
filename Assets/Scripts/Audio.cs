using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource _audio = default;
    
    
    [SerializeField] public AudioClip _jump1 = default;
    [SerializeField] public AudioClip _jump2 = default;
    [SerializeField] public AudioClip _damage = default;
    PlayerController _playerController = default;
    



    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _playerController = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetButtonDown("Jump"))
        {
            if (_playerController._jumpCount == 0)
            {
                _audio.PlayOneShot(_jump1);
                
            }
            else if (_playerController._jumpCount  == 1)
            {
                _audio.PlayOneShot(_jump2);
            }
           
        }

        //if (Destroy(_player))
        {

        }
    }

    
}
