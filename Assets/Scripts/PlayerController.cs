using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    [SerializeField] float _jumpPower = 10;
    [SerializeField] public AudioClip _jump1 = default;
    [SerializeField] public AudioClip _jump2 = default;

    Rigidbody2D _rb2d = default;
    Animator _anim = default;
    AudioSource _audio = default;
    int _jumpCount = 0;
    bool _isGround = false;
    int _stepOnCount = 0;

    




    void Start()
    {
        _audio = GetComponent<AudioSource>();

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
        GameObject _bossEnemy = GameObject.FindGameObjectWithTag("BossEnemy");

        if (collision.gameObject.CompareTag("Ground")) //地面にいるとき
        {
            _isGround = false;
            _jumpCount = 0;
            _anim.Play("Idle");
        }

        if (collision.gameObject.CompareTag("Head")) //エネミーを踏んだとき
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            _rb2d.velocity = Vector2.up * _jumpPower;
            _anim.Play("PlayerJump");

        }

        if (collision.gameObject.CompareTag("BossEnemy") ) //ボスを踏んだとき
        {
            _stepOnCount++;
            Debug.Log("++");
            _rb2d.AddForce(Vector2.up * _jumpPower * 80);

        }
        if (_stepOnCount == 5)
        {
            Destroy(_bossEnemy);
        }
    }


}
