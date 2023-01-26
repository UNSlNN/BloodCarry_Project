using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveToFile : MonoBehaviour
{
    public GameData data;
    string dataFilePath;
    BinaryFormatter bf;

    public void UpdateDataBeforeSave()
    {
        //1.ตัวแปรทุกตัวที่ต้องการจะบันทึกลงไฟล์-----<แก้ตรงนี้
        data.updateStars = SaveData.updateStars;
    }
    private void UpdateDataToGame()
    {
        //2.ตัวแปรทุกตัวที่ต้องการจะบันทึกลงไฟล์-----<แก้ตรงนี้
        data.updateStars = SaveData.updateStars;

    }
    private void Awake()
    {
        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.text";
    }
    public void SaveDataToFile()
    {
        UpdateDataBeforeSave();
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }
 
    public void LoadDataToGame()
    {
        if(File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (GameData)bf.Deserialize(fs);
            fs.Close();
            UpdateDataToGame();
        }
    }
    private void OnEnable()
    {
        LoadDataToGame();
    }
    private void OnDisable()
    {
        SaveDataToFile();
    }
}
