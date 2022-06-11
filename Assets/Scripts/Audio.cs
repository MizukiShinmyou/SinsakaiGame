using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource _audio = default;
    
    private int _jumpCount = 0;
    [SerializeField] public AudioClip _jump1 = default;
    [SerializeField] public AudioClip _jump2 = default;

    bool _isGround = true;



    void Start()
    {
        _audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
           
        }
    }
}
