using UnityEngine;

public class CarSpinning : MonoBehaviour
{
    public GameObject car; // Reference to the car GameObject
    public GameObject stage;
    public float rotationSpeed = 10f; // Speed of rotation

    void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
       
    }
    void Update()
    {
        if (car.name == "MonsterTruck")
        {
            car.transform.position = new Vector3(0, 0.68f, 0);
        }
        else
        {
            car.transform.position = new Vector3(0, 0.37f, 0);
        }
        // Rotate the car around its Y-axis
        car.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        stage.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            
        
        
    }
}