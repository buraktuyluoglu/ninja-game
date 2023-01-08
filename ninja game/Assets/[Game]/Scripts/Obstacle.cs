using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{   
    // Topları oluşturmak için bir prefab
    public GameObject obstaclePrefab;
    // Topların oluşturulacağı aralık
    public float obstacleInterval = 3f;
    public GameObject panel;

    // Bir sonraki topun oluşturulacağı zaman
    float nextObstacleTime;

    // Start is called before the first frame update
    void Start()
    {
        // İlk topun oluşturulacağı zaman
        nextObstacleTime = Time.time + obstacleInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Eğer geçen zaman bir sonraki topun oluşturulacağı zamandan büyükse
        if (Time.time > nextObstacleTime)
        {
            // Bir sonraki topun oluşturulacağı zamanı güncelle
            nextObstacleTime = Time.time + obstacleInterval;

            // Bir top oluştur
            CreateObstacle();
        }
    }

    GameObject obstacle;

void CreateObstacle()
{
    // Topların oluşturulacağı yerlerin koordinatları
    Vector3[] positions = { new Vector3(-8, 0, 0), new Vector3(8, 0, 0) };

    // Bir pozisyon rastgele seç
    int index = Random.Range(0, positions.Length);
    Vector3 position = positions[index];

    // Topu oluştur
    obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);

    // Topun Rigidbody component'ine erişin
    Rigidbody rb = obstacle.GetComponent<Rigidbody>();

    // Topun hızını ayarla
    if (index == 0)
    {
        rb.velocity = new Vector3(1, 0, 0) * 6f;
    }
    else
    {
        rb.velocity = new Vector3(-1, 0, 0) * 6f;
    }

    // Topun yok edileceği zamanı belirle
    Destroy(obstacle, 3.5f);
}

void OnCollisionEnter(Collision other)
{
    if (other.gameObject.tag == "Player")
    {
        Destroy(obstacle);
    }
}

}
