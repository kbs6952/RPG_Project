using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class DataHandler 
{
    private string directoryPath = "";
    private string fileName = "";

    public DataHandler(string directoryPath, string fileName)
    {
        this.directoryPath = directoryPath;
        this.fileName = fileName;
    }

    public void DataSave(GameData _data)
    {
        string datapath = Path.Combine(directoryPath, fileName);

        try
        {
            Debug.Log(datapath);

            Directory.CreateDirectory(Path.GetDirectoryName(datapath));
            string serializeData = JsonUtility.ToJson(_data, true);       // true : �鿩���� + �ٹٲ� ���� ���·� json�� �������ݴϴ�.

            using (FileStream stream = new FileStream(datapath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(serializeData);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("���� �߻�" + datapath + "\n" + e);
        }
    }

    public GameData DataLoad()
    {
        string datapath = Path.Combine(directoryPath, fileName);
        GameData loadData = null;

        if (File.Exists(datapath)) // �ش� ��ο� ������ ������ null�� ��ȯ�ض�.
        {
            try
            {
                string dataToLoad = "";

                using(FileStream stream = new FileStream(datapath, FileMode.Open))
                {
                   using(StreamReader reader = new StreamReader(stream))
                   {
                        dataToLoad = reader.ReadToEnd();
                   }
                }

                loadData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("���� �߻�" + datapath + "\n" + e);
            }
        }


        return loadData;
    }

    public void DataDelete()
    {
        string deletePath = Path.Combine(directoryPath, fileName);

        if (File.Exists(deletePath))
            File.Delete(deletePath);
    }

    public bool CheckFileExists(string dir, string file)
    {
        if(File.Exists(Path.Combine(dir, file)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
