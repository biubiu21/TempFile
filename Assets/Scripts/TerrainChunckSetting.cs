using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunckSetting : MonoBehaviour {

    public int HeightmapResolution;
    public int AlphamapResolution;
    public int Length;
    public int Height;

    public TerrainChunckSetting(int a,int b,int c,int d) {
        HeightmapResolution = a;
        AlphamapResolution = b;
        Length = c;
        Height = d;
    }
}
