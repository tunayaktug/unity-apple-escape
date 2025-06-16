using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    private float minSpeed;
    private Rigidbody _rb;
    public bool isCollected;
    public GameDirector gameDirector;
    private bool isCharacterWalking;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("hello world" , this);
        minSpeed = speed;
        
    }

    public void RestartPlayer()
    {
        gameObject.SetActive(true);
        _rb = GetComponent<Rigidbody>();
        _rb.position = new Vector3(-10.9f, 0.5f, 0);
        isCollected = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag, this);

       


        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            gameDirector.levelManager.Collected();
            isCollected = true;
        }

        if (other.CompareTag("Door") && isCollected)
        {
            gameDirector.levelCompleted();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        var direction = Vector3.zero;
        
        if (Input.GetKey(KeyCode.Y))
        {
            speed = maxSpeed;
            SetWalkAnimationSpeed(2.5f);
        }

        else
        {
            speed = minSpeed;
            SetWalkAnimationSpeed(1f);
        }


        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
          
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
          
        }
        
        if (_rb.linearVelocity.magnitude > 0.1f)
        {
            TriggerWalkAnimation();
        }
        else
        {
            TriggerIdleAnimation();
        }
        transform.LookAt(transform.position + direction);
        _rb.linearVelocity = direction.normalized * speed;
        // transform.position += direction * speed;
        
    }

    void TriggerWalkAnimation()
    {
        if (!isCharacterWalking)
        {
            animator.SetBool("Walk", true);
            isCharacterWalking = true;
        }
    }

    void TriggerIdleAnimation()
    {
        animator.SetBool("Walk", false);
        isCharacterWalking = false;
    }
    
    void SetWalkAnimationSpeed(float s)
    {
        animator.SetFloat("WalkSpeedMultiplier", s);
    }
}
