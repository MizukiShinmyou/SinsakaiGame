using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform _targets;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _stoppingDistance = 0.05f;
    
    private SpriteRenderer sr = default;
    private Transform tr = default;
    public GameObject _enemy = default;
    int _currentTargetIndex = 0;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {


        if (sr.isVisible)
        {
            Patrol();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //‚ ‚½‚Á‚½‚çDestroy‚·‚éB
    {
        if (collision.collider)
        {
            //Destroy(this.gameObject);
        }
    }

    void Patrol()
    {
        float distance = Vector2.Distance(this.transform.position, _targets.position);



        if (distance > _stoppingDistance)
        {
            Vector2 dir = (_targets.transform.position - this.transform.position).normalized * _moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            _currentTargetIndex++;
        }
    }
}