using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public Rigidbody car;
    public float uprightThreshold = 0.5f;
    float upsideDownTime = 0f;
    public float autoFlipDelay = 2f;

    void Start()
    {
        //print(GameObject.Find("car(Separate)2").transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        if (car.transform.position.y < 0)
        {
            car.transform.position = new Vector3(0, 2.8f, 0);
            car.transform.rotation = new Quaternion(0, 0, 0, 0);
            car.linearVelocity = new Vector3(0, 0, 0);
            car.angularVelocity = new Vector3(0, 0, 0);
        }


        if (IsUpsideDown())
         {
        upsideDownTime += Time.deltaTime;

        if (upsideDownTime >= autoFlipDelay)
        {
            FlipCar();
            upsideDownTime = 0f;
        }
    }
    else
    {
        upsideDownTime = 0f;
    }
    }

    bool IsUpsideDown()
    {
        // If dot product between car's up vector and world up vector is negative, it's upside down
        return Vector3.Dot(transform.up, Vector3.up) < uprightThreshold;
    }
    
    void FlipCar()
    {
        // Slightly lift the car and reset rotation
        transform.position += Vector3.up * 1.5f;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        // Reset velocity so it doesn’t keep flipping
        car.linearVelocity = Vector3.zero;
        car.angularVelocity = Vector3.zero;
    }
}
