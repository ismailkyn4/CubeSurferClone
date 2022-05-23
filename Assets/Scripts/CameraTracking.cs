using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private GameObject mainCube;
    [SerializeField] Vector3 distance;
    float cameraTrackingSpeed=1.5f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, mainCube.transform.position + distance, Time.deltaTime*cameraTrackingSpeed); //kamera takibi yumuþak bir þekilde olmasý için lerp ile yazdýk.
    }
}
