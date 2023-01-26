using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    //1.ข้อมูลที่จะบันทึกลงไฟล์------<แก้ตรงนี้
    int updateStars;


    /*ข้อมูลทดสอบ (ให้ตัดออกได้เวลาใช้งานจริง)*/
    public Text showCoin;
    public Text showScore;
    

    void SaveDataToGameObject() //
    {
        //2.ข้อมูลที่จะบันทึกลงไฟล์------<แก้ตรงนี้
        SaveData.updateStars = updateStars;
    }

    void UpdateDataToScene() //
    {
        //3.ดึงข้อมูลจากไฟล์มาใช้งาน------<แก้ตรงนี้
        updateStars = SaveData.updateStars;
    }
    private void Update()
    {
        UpdateDataToScene(); //ห้ามลบ เอาไว้บนสุดของ Update



        /*ข้อมูลสำหรับการทดสอบตัดออกเวลาใช้งานจริง
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coin +=1;
            
            if(coin%2 == 0)
            {
                score +=1;
            }
        }

        showCoin.text = SaveData.coin.ToString();
        showScore.text = SaveData.score.ToString();
        --------------------------------------*/

        



        SaveDataToGameObject(); //ห้ามลบ เอาไว้ล่างสุดของ Update
    }
}
