using UnityEngine;
using System.Collections;

public class SinkOut : MonoBehaviour
{
    public float destroyDelay = 5f;  // Time before sinking starts
    public float sinkDuration = 3f;  // Time it takes to fully sink
    public float sinkDistance = 2f;  // How deep it sinks

    void Start()
    {
        StartCoroutine(SinkAndDestroy());
    }

    IEnumerator SinkAndDestroy()
    {
        yield return new WaitForSeconds(destroyDelay);

        SetLayerRecursively(gameObject, LayerMask.NameToLayer("Object3"));
        BlockChildrenRotation();

        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        Vector3[] startPositions = new Vector3[childTransforms.Length];
        Vector3[] endPositions = new Vector3[childTransforms.Length];

        for (int i = 0; i < childTransforms.Length; i++){
            startPositions[i] = childTransforms[i].localPosition;
            endPositions[i] = startPositions[i] + (Vector3.down * sinkDistance);
        }

        float elapsedTime = 0f;

        while (elapsedTime < sinkDuration)
        {
            for (int i = 0; i < childTransforms.Length; i++)
            {
                childTransforms[i].localPosition = Vector3.Lerp(startPositions[i], endPositions[i], elapsedTime / sinkDuration);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < childTransforms.Length; i++){
            childTransforms[i].localPosition = endPositions[i];
        }

        Destroy(gameObject);
    }

    void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);
        }
    }

    void BlockChildrenRotation()
{
    Transform[] childTransforms = GetComponentsInChildren<Transform>();
    foreach (Transform child in childTransforms)
    {
        Rigidbody rb = child.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
       
    }
}
}