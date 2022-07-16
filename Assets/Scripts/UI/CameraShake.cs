using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour {
    
    private CinemachineVirtualCamera virtCam;
    private static CameraShake instance;

    public static CameraShake GetInstance() { return instance; }

    private void Awake() {
        instance = this;
        virtCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float duration) {
        CinemachineBasicMultiChannelPerlin perlin = virtCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine(DecreaseShake(intensity, duration, perlin));
    }

    IEnumerator DecreaseShake(float duration, float intensity, CinemachineBasicMultiChannelPerlin perlin) {
        float t = 0f;
        while(t <= 1f) {
            t += Time.deltaTime / duration;
            perlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0, t);
            yield return null;
        }

        perlin.m_AmplitudeGain = 0;
    }

}
