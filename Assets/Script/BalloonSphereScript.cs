using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSphereScript : MonoBehaviour
{
    [SerializeField] private Vector3 localGravity;
    private Rigidbody rb;

    GameObject gameMgrObj;
    GameManager gameMgr;

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
        if (collision.gameObject.name == "Player_unitychan") {
            // Bounce回数を一つ増やす
            gameMgr.addBounce();
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
