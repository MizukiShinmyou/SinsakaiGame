using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource _audio = default;
    
    
    [SerializeField] public AudioClip _jump1 = default;
    [SerializeField] public AudioClip _jump2 = default;
    PlayerController _playerController = default;
    



    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _playerController = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
           
        }
    }
}
