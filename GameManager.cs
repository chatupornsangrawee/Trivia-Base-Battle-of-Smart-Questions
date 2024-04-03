using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float countdownTime = 600.0f; // 10 นาที
    private float currentTime;
    public Text timerText;

    // ประกาศตัวแปรสำหรับเก็บชื่อฉากถัดไป
    public string nextSceneName = "NextScene";

    void Start()
    {
        currentTime = countdownTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // หมดเวลา โหลดฉากเดิม
            LoadNextScene();
        }

        // ตรวจสอบว่ามีวัตถุที่มีชื่อ "Target" ที่ยังไม่ถูกทำลาย
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        if (targets.Length == 0)
        {
            // ถ้าไม่มี Target ที่เหลือ ให้โหลดฉากต่อไป
            LoadNextScene();
        }
    }

    void UpdateTimerDisplay()
    {
        // แปลงเวลาในรูปแบบนาทีและวินาที
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // แสดงเวลาที่หน้าจอ
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void LoadNextScene()
    {
        // โหลดฉากตามชื่อที่กำหนด
        SceneManager.LoadScene(nextSceneName);
    }
}
