using UnityEngine;
using UnityEngine.UI;

public class IgnoreTransparency : MonoBehaviour {
    void Start() {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
    }
}
