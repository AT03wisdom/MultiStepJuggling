using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSphereScript : MonoBehaviour
{
    [SerializeField] private Vector3 localGravity;
    private Rigidbody rb;

    GameObject gameMgrObj;
    GameManager gameMgr;

    public float xForce;
    public float zForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;

        gameMgrObj = GameObject.Find ("GameManager");
        gameMgr = gameMgrObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // ?
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player_unitychan" && collision.gameObject.transform.position.y < this.transform.position.y) 
        {
            // Bounce回数を一つ増やす
            gameMgr.addBounce();
        }
        else if(collision.gameObject.name == "EdgeWall-N") // EdgeWall-N collision
        {
            xForce = Random.Range(-1,1);
            rb.velocity = Vector3.zero;
            rb.AddForce(xForce, 0, -2, ForceMode.VelocityChange);
        }
        else if(collision.gameObject.name == "EdgeWall-S") // EdgeWall-S collision
        {
            xForce = Random.Range(-1,1);
            rb.velocity = Vector3.zero;
            rb.AddForce(xForce, 0, 2, ForceMode.VelocityChange);
        }
        else if(collision.gameObject.name == "EdgeWall-E") // EdgeWall-E collision
        {
            zForce = Random.Range(-1,1);
            rb.velocity = Vector3.zero;
            rb.AddForce(-2, 0, zForce, ForceMode.VelocityChange);
        }
        else if(collision.gameObject.name == "EdgeWall-W") // EdgeWall-W collision
        {
            zForce = Random.Range(-1,1);
            rb.velocity = Vector3.zero;
            rb.AddForce(2, 0, zForce, ForceMode.VelocityChange);
        } else {
            // Bounce回数を一つ増やす
            gameMgr.addDropped();
        }
        Debug.Log(collision.gameObject.name); // ログを表示する
    }

    void FixedUpdate()
    {
        SetLunarGravity();
    }

    private void SetLunarGravity()
    {
        // balloon gravity : y = -2 （月よりも少し強い）
        // 難易度によって可変するかもね
        rb.AddForce(localGravity, ForceMode.Acceleration);
    }
}
