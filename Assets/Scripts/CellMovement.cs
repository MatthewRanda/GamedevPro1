using System.Diagnostics;
using UnityEngine;

public class CellMovement : MonoBehaviour 
{
    
    public float speed = 5f; 

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        
        float moveY = Input.GetAxis("Vertical"); 
    
        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized; 

        transform.position += movement * speed * Time.deltaTime; 
 
    }


    
}
