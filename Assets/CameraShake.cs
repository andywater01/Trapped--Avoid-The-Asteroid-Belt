using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Update()
    {
       
        
    }


    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, orignalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = orignalPosition;
    }
}
