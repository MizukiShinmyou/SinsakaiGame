using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    [SerializeField] float _jumpPower = 10;

    Rigidbody2D _rb2d = default;
    Animator _anim = default;
    int _jumpCount = 0;
    bool _isGround = false;
    

    void Start()
    {
        if (!TryGetComponent(out _rb2d))
        {
            Debug.Log("Rigidbody2D が取得できませんでした。");
        }

        //_rb2d = GetComponent<Rigidbody2D>();

        _anim = GetComponent<Animator>();
        TryGetComponent(out _anim);
        //GameObject.Find("_enemy");
    }

    void Update()
    {
        // インプット（水平の入力）
        var x = Input.GetAxisRaw("Horizontal");
        var jump = Input.GetButtonDown("Jump");

        if (jump && _jumpCount < 2)
        {
            _anim.Play("PlayerJump");
            _rb2d.velocity = Vector2.up * _jumpPower;
            _jumpCount++;
            _isGround = true;
        }

        var velo = _rb2d.velocity;

        if (x != 0)
        {
            velo.x = x * _speed * Time.deltaTime;
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
            if(!_isGround)
            {
                _anim.Play("PlayerRun");
            }
        }
        else
        {
            velo.x = 0;
            _anim.Play("Idle");
        }


        _rb2d.velocity = velo;

    }

    /// <summary>
    /// JumpCountをリセット
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = false;
            _jumpCount = 0;
            _anim.Play("Idle");
        }

        
    }


}
