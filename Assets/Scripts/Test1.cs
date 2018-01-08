using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Test1 : MonoBehaviour {


    int num = 128;//图片像素
    int height = 20;
	// Use this for initialization
	void Start () {
        int terrainLength = num * 4;
        var settings = new TerrainChunckSetting(num, num, terrainLength, height);
        TerrainChunck terrain = new TerrainChunck(settings, getTxtHeightmap(), 0, 0);
        terrain.CreateTerrain();


    }
    private float[,] getRandomHeightmap() {
        float[,] randomValues= new float[num, num];
        for (int i = 0; i < num; i++) {
            for (int j = 0; j < num; j++) {
                randomValues[i, j] = Random.Range(0.5f, 7f);
            }
        }
        return randomValues;
    }
    private float[,] getTxtHeightmap() {
        float[,] txtValues = new float[num, num];
        var fileAddress = System.IO.Path.Combine(Application.streamingAssetsPath, "xxx.txt");
        FileInfo file = new FileInfo(fileAddress);
        string fielStr = "";
        if (file.Exists) {
            StreamReader sr = new StreamReader(fileAddress);
            fielStr = sr.ReadToEnd();
            string[] rowArr = fielStr.Split(',');
            for(int i = 0; i < rowArr.Length; i++) {
                string[] colArr = rowArr[i].Split(' ');
                for(int j = 0; j < colArr.Length; j++) {
                    txtValues[i,j] = float.Parse(colArr[j]);
                }
            }
        }

        return txtValues;
    }


}
