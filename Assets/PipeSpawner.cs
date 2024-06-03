using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxtime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;

    [SerializeField] private float _spawnDuration = 30f; // 30 saniye bekleyece�imiz s�re
    private float _elapsedTime = 0f;

    private float _timer;

    void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (_elapsedTime < _spawnDuration)
        {
            if (_timer > _maxtime)
            {
                SpawnPipe();
                _timer = 0;
            }
            _timer += Time.deltaTime;
            _elapsedTime += Time.deltaTime; // Ge�en s�reyi artt�r
        }
    }

    // Update is called once per frame
    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }

    // �arp��ma alg�land���nda �al��acak metod
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RestartScene(); // Sahneyi yeniden ba�lat
        }
    }

    // Sahneyi yeniden ba�latan metod
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}