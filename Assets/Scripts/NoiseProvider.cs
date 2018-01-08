using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise.Generator;
public class NoiseProvider : MonoBehaviour {
    private Perlin PerlinNoise;
    public NoiseProvider() {
        PerlinNoise = new Perlin();
    }
    public float GetValue(float x,float z) {
        return (float)(PerlinNoise.GetValue(x, 0, z) / 2f + 0.5f);
    }

}
