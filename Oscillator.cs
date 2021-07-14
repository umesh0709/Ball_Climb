using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] float movementOffset = 2f;
    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    float movementFactor;

   

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycle = Time.time / period;
        const float tau = Mathf.PI * 2f;

        float rawSinWave = Mathf.Sin(cycle * tau);

        movementFactor = rawSinWave / movementOffset;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
