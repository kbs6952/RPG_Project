using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class CSVtoSO
{
    public static string enemyDataCSVPath = "/4_Data/CSV//EnemyCSV.csv";
    public static string saveAssetPath = "Assets/4_Data/Monster";

    [MenuItem("Tools/CSV to ScriptableObject")]
    public static void GenerateEnemyScriptableObject()
    {
        Debug.Log(Application.dataPath + enemyDataCSVPath);

        string[] allLine=File.ReadAllLines(Application.dataPath + enemyDataCSVPath);

        foreach(string s in allLine) 
        {
            string[] splitData = s.Split(',');

            if(splitData.Length !=4)
            {
                Debug.Log("데이터의 수가 일치하지 않습니다.");
                return;
            }
            ZombieData enemy = ScriptableObject.CreateInstance<ZombieData>();
            enemy.ZombieName = splitData[0];
            enemy.HP = int.Parse(splitData[1]);
            enemy.Attack = int.Parse(splitData[2]);
            enemy.AttackRange = float.Parse(splitData[3]);

            AssetDatabase.CreateAsset(enemy, $"{saveAssetPath}/{enemy.ZombieName}.asset");
        }
        AssetDatabase.SaveAssets();
    }
}
