using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
   [SerializeField] float steerSpeed=1f;
   [SerializeField] float moveSpeed=20f;
   [SerializeField] float slowSpeed=15f;
   [SerializeField] float boostSpeed=25f;


   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      



      if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
      {
        float steerAmount=Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
       float moveAmount=Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;


        transform.Rotate(0,0,-steerAmount);

        transform.Translate(0,moveAmount,0);

      }
      else
      {
          
      }

     
      


    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.tag=="Boost")
       {
       Debug.Log("You are speeding up!");

       moveSpeed=boostSpeed;
       }

       if(other.tag=="Bump")
       {
       Debug.Log("You are slowing down! Try to avoid Bumps...");
       moveSpeed=slowSpeed;
       }
    }


    void OnCollisionEnter2D(Collision2D other)
    {

      moveSpeed=slowSpeed;

    }
    
    
}
