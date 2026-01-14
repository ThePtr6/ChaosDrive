using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using TMPro;
using NWH.VehiclePhysics2;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    public GameObject objectFromGame;
    public GameObject objectPrefab;
    private CoinUIGame coinUI;
    private CoinUIGame numberOfCoins;
    private bool hasActivated = false;

    [System.Obsolete]
   
    void Start()
    {
        numberOfCoins = FindObjectOfType<CoinUIGame>();
        try
        {
            coinUI = FindObjectOfType<CoinUIGame>();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error finding CoinUI: " + e.Message);
        }
   
    }

    void OnTriggerEnter(Collider other)
  {
        if (hasActivated)return; 
        
       
        if (objectFromGame != null && objectPrefab != null)
        {


            // Store position and rotation
            Vector3 spawnPosition = objectFromGame.transform.position;
            Quaternion spawnRotation = objectFromGame.transform.rotation;
            Vector3 spawnScale = objectFromGame.transform.localScale;

            // Destroy the original object
            Destroy(objectFromGame);

            // Instantiate the prefab at the same position and rotation
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);
            spawnedObject.transform.localScale = spawnScale;


            // Optionally invoke UnityEvent and update coin UI
            numberOfCoins.UpdateCoinUI();
            onTriggerEnter?.Invoke();
            //coinUI?.UpdateCoinUI();

            hasActivated = true;

        }
}

// void SetLayerRecursively(Transform obj, int newLayer)
// {
//     obj.gameObject.layer = newLayer;

//     foreach (Transform child in obj)
//     {
//         SetLayerRecursively(child, newLayer);
//     }
// }
}