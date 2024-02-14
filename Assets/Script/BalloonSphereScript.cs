using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSphereScript : MonoBehaviour
{
    [SerializeField] private Vector3 localGravity;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ?
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
