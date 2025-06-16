using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;
    private bool isWalking;
    public Transform ZPrefab;
    private Transform z1;
    private Transform z2;
    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0, UnityEngine.Random.Range(-180, 180), 0);
        CreateAndAnimateZ();

        
    }

    private void CreateAndAnimateZ()
    {
        z1 = Instantiate(ZPrefab, transform);
        z1.position = transform.position + Vector3.up*2;
        z1.localScale = Vector3.zero;
        z1.DOMoveY(z1.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        z1.DOScale(1, 1f).SetLoops(-1, LoopType.Restart);
        z1.LookAt(transform.position + Vector3.forward);

        z2 = Instantiate(ZPrefab, transform);
        z2.position = transform.position + Vector3.up * 2;
        z2.localScale = Vector3.zero;
        z2.DOMoveY(z2.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
        z2.DOScale(1, 1f).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
        z2.LookAt(transform.position + Vector3.forward);
    }

    private void Update()
    {
        if (_player.isCollected)
        {
            //var direction = (_player.transform.position - transform.position).normalized;
            //direction.y = 0;
           // _rb.position += direction * speed;
           navMeshAgent.destination = _player.transform.position;
            if (!isWalking)
            {
                isWalking = true;
                _animator.SetTrigger("Walk");
                z1.DOKill();
                z2.DOKill();
                Destroy(z1.gameObject);
                Destroy(z2.gameObject);
            }
            
        } 
    }

    public void Stop()
    {
        navMeshAgent.speed = 0;
        _animator.SetTrigger("Idle");
    }
}
