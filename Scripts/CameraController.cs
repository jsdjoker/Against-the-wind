using System.Collections;
using System.Timers;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFov = 20f;
    [SerializeField] float maxFov = 120f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;



    CinemachineCamera cinemachineCamera;

      void Awake()
    {
       cinemachineCamera = GetComponent<CinemachineCamera>(); 
    }

    public void ChangeCameraFov(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFovRoutine(speedAmount));
    }

    IEnumerator ChangeFovRoutine(float speedAmount)
    {
        float startFov = cinemachineCamera.Lens.FieldOfView;
        float targetFov = Mathf.Clamp(startFov + speedAmount * zoomSpeedModifier, minFov, maxFov);

        float elaspedTime = 0f;

        while (elaspedTime < zoomDuration)
        {
            float t = elaspedTime / zoomDuration;
            elaspedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFov, targetFov, t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFov;
    }

}
