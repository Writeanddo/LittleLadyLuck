using UnityEngine;
using System.Collections.Generic;

public class RandomColor : MonoBehaviour {
    private List<Color> colors = new List<Color>();

    void Start() {
        colors.Add(new Color(.95f, .24f, .21f, 1f)); // red
        colors.Add(new Color(.15f, .68f, 0f, 1f)); // green
        colors.Add(new Color(.39f, .37f, 1f, 1f)); // blue
        // colors.Add(new Color(1f, 1f, 1f, 1f)); // guess
        
        int c = Random.Range(0, colors.Count);
        GetComponent<SpriteRenderer>().color = colors[c];
    }
}
