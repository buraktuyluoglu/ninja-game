using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Text : MonoBehaviour
{
TextMeshProUGUI countdownText;
public int countdownTime = 20;
public GameObject panel;
void Start()
{
    // 1 dakika süresi olsun
    countdownText = GameObject.Find("Canvas/countdownText").GetComponent<TextMeshProUGUI>();
    // Geri sayım işlemini başlat
    StartCoroutine(StartCountdown(countdownTime));
    
}

IEnumerator StartCountdown(int countdownTime)
{
    // Süreyi saniye cinsinden tutalım
    int countdownTimeInSeconds = countdownTime;
    NinjaController n1 = new NinjaController();

    // Süre bitene kadar geri sayım işlemini sürdür
    while (countdownTimeInSeconds > 0)
    {
        // Geri sayım metnini güncelle
        
        countdownText.text = countdownTime + " seconds remaining";
        // Bir saniye bekle
        yield return new WaitForSeconds(1);

        // Süreyi 1 saniye azalt
        countdownTimeInSeconds--;
        countdownTime--;
    }

    
    // Geri sayım bittiğinde "Time's up!" metnini göster
    countdownText.text = "you win!";
    panel.SetActive(true);
    Time.timeScale = 0.0f;
}


// Update is called once per frame
void Update()
{   
    

}
public void youLose(){
    countdownText.text = "you lose!";
}

public void TekrarOyna()
{
    // Oyunu tekrar başlat
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Time.timeScale = 1.0f;
}

}