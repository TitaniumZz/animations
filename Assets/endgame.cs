using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 30f; 
    
    [SerializeField] private GameObject _endGameObject;
    public GameObject spawnPos;

    private bool _spawned = false; 

    private void Start()
    {
        StartCoroutine(SpawnEndGameDelayed());
    }

    private IEnumerator SpawnEndGameDelayed()
    {
        yield return new WaitForSeconds(_spawnDelay);

     
        if (!_spawned)
        {
            SpawnEndGame();
            _spawned = true;
        }
    }

    private void SpawnEndGame()
    {
        Vector3 spawnPosition = spawnPos.transform.position;
        spawnPosition.y = 9.5f; // Yüksekliði sýfýr olarak ayarla
        Instantiate(_endGameObject, spawnPosition, Quaternion.identity);
    }
}