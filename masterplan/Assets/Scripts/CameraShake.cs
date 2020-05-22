using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Set up data
    bool shake = false;
    float duration;
    float magnitude;
    Vector3 originalPos;
    float elapsed;

    // Shake the screen
    public IEnumerator Shake(float duration, float magnitude)
    {
        // Setup data for camera to be shaked
        shake = true;
        this.duration = duration;
        this.magnitude = magnitude;
        yield return 0;
    }

    void Update()
    {
        // Shake the camera
        if (shake)
        {
            if (elapsed == 0.0f)
            {
                Vector3 originalPos = transform.localPosition; // Save the original position
            }
            // Every frame, offset the camera's x and y position for duration seconds for duration seconds
            if (elapsed < duration)
            {
                float x = Random.Range(-1, 1f) * magnitude;
                float y = Random.Range(-1, 1f) * magnitude;
                transform.localPosition = new Vector3(x, y, originalPos.z);
                elapsed += Time.deltaTime;
            }
            else // Reset data
            {
                transform.localPosition = Vector3.zero;
                shake = false;
                elapsed = 0.0f;
            }
        }
    }
}
