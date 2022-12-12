using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;
   public Vector3 offset;
    public float cameraclampy;
    private void Start() {
        cameraclampy=-2.7f;
    }
   private void FixedUpdate(){
       transform.position=target.position+offset;
       transform.position=new Vector3(Mathf.Clamp(transform.position.x,-8.9f,38.8f),Mathf.Clamp(transform.position.y,cameraclampy,2.7f),transform.position.z);
   }
   
}
