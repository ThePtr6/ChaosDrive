using UnityEngine;

public class GetAsset : MonoBehaviour
{
    

    public GameObject GetAssetByName(string assetName)
    {
        GameObject asset = Resources.Load<GameObject>("Blocks/"+assetName);
        if (asset == null)
        {
            Debug.LogError($"Asset '{assetName}' not found in Resources.");
            return null;
        }
        return asset;
    }
}
