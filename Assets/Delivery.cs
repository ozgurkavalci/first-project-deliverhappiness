using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor= new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor=new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    [SerializeField] float destroyDelay=0.5f;
    bool hasPackage;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouuchh!That must've hurt");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    
    {
        //Debug.Log("You have just passed through something mate!");
      
      if (other.tag=="Package"&& !hasPackage)
      {
          Debug.Log("Package has been picked up!");
          hasPackage=true;
          spriteRenderer.color=hasPackageColor;
          Destroy(other.gameObject,destroyDelay);
      }
      
      if(other.tag=="Customer"&& hasPackage)
      {

          Debug.Log("Customer has received the Package!");
          hasPackage=false;
          spriteRenderer.color=noPackageColor;
          Destroy(other.gameObject,destroyDelay);

      }


    }
}
