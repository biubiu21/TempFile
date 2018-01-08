using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise.Generator;
using System.IO;

public class TerrainChunck : MonoBehaviour {

    public int X;
    public int Z;
    private Terrain Terrain;
    private TerrainChunckSetting Settings;
    private NoiseProvider NoiseProvider;

    float[,] HeightmapValues;




    public TerrainChunck(TerrainChunckSetting a,float[,] b,int c,int d) {
        Settings = a;
        HeightmapValues = b;
        X = c;
        Z = d;
    }
    public void CreateTerrain() {
        var terrainData = new TerrainData();
        terrainData.heightmapResolution = Settings.HeightmapResolution;
        terrainData.alphamapResolution = Settings.AlphamapResolution;

        //var heightmap = GetHeightmap();
        //print("0,0="+ HeightmapValues[0,0]);
        terrainData.SetHeights(0,0, HeightmapValues);
        terrainData.size = new Vector3(Settings.Length,Settings.Height,Settings.Length);

        var newTerrain = Terrain.CreateTerrainGameObject(terrainData);
        newTerrain.transform.position = new Vector3(X * Settings.Length, 0, Z * Settings.Length);
        newTerrain.GetComponent<Terrain>().Flush();

    }

    private float[,] GetHeightmap() {
        var resolution = Settings.HeightmapResolution;
        var heightmap = new float[resolution, resolution];
        for(var zRes = 0; zRes < resolution; zRes++) {
            for(var xRes = 0; xRes < resolution; xRes++) {
                var xCoordinate = X + (float)xRes / (resolution - 1);
                var zCoordinate = Z + (float)zRes / (resolution - 1);
                //heightmap[zRes, xRes] = NoiseProvider.GetValue(xCoordinate, zCoordinate);
                heightmap[zRes, xRes] = 0.5f;
                print(zRes+","+ xRes+":" +heightmap[zRes, xRes]+"!");

            }
            heightmap[3, 3] = -1f;
        }
        return heightmap;
    }

}
