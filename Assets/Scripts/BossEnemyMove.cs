using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyMove : MonoBehaviour
{
    [SerializeField] Transform[] _targets;
    int _currentTargetIndex = 0;
    [SerializeField] float _moveSpeed;

    [SerializeField] float _jumpTimeLimit = 2.0f;
    float _jumpTime;
    [SerializeField] float _jumpForce;
    Rigidbody2D _rb2d;
    Vector2 _pos;
    public int _num;
    
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        StartCoroutine(LoopJump());
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(this.transform.position, _targets[_currentTargetIndex % _targets.Length].position);

        if (distance > 4f)
        {
            Vector2 dir = (_targets[_currentTargetIndex % _targets.Length].transform.position - this.transform.position).normalized * _moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            Debug.Log("インデックス番号増加");
            _currentTargetIndex++;
        }
    }


    IEnumerator LoopJump()
    {
        while (true)
        {
            var _rnd = Random.Range(3, 10);
            this._rb2d.AddForce(transform.up * _jumpForce);
            yield return new WaitForSeconds(_rnd);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject _player = GameObject.FindGameObjectWithTag("Player");

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(_player);
        }
    }


}
