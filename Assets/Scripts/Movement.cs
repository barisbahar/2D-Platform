using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public float MovementSpeed = 5;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public Animator animator;
    public GameObject spawnpoint,finishscene;
    public bool check=false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        finishscene.SetActive(false);
        this.gameObject.transform.position=spawnpoint.transform.position;
    }


    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if (movement != 0)
        {
            animator.SetBool("Run", true);
            if(GameManager.FindObjectOfType<GameManager>().lightcheck==true&& check==false)
            {
                CountdownTime.FindObjectOfType<CountdownTime>().speed+=3;
                check=true;
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            animator.SetBool("Run",false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Camera"){
          CameraFollow.FindObjectOfType<CameraFollow>().cameraclampy=-9.6f;
       }
       if(other.gameObject.tag=="Poison"){
           CountdownTime.FindObjectOfType<CountdownTime>().gameoverscene.SetActive(true);
       }
        if(other.gameObject.tag=="Finish"){
            finishscene.SetActive(true);
       }
    }

}
