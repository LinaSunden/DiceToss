using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown (KeyCode.Space))
        {
            // Use the current system time as the seed for the random number generator
            Random.InitState((int)System.DateTime.Now.Ticks);

            DiceNumberTextScript.diceNumber = 0;
            transform.position = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.identity;

            // Apply force in a random direction with a random magnitude
            float forceMagnitude = Random.Range(200, 800);
            Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(forceDirection * forceMagnitude);

            // Apply torque with random values
            float torqueX = Random.Range(0, 500);
            float torqueY = Random.Range(0, 500);
            float torqueZ = Random.Range(0, 500);
            rb.AddTorque(torqueX, torqueY, torqueZ);
        }
    }
}
