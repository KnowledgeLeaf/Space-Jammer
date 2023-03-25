using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingManager : MonoBehaviour
{
    ObjectPool<StationScript> _stationPool;
    [SerializeField] private StationScript _stationPrefab;

    private void Update()
    {
        
    }

    void Awake() => new ObjectPool<StationScript>(CreateStation, OnTakeStationFromPool, OnReturnStationToPool);

    private void OnTakeStationFromPool(StationScript station)
    {
        station.gameObject.SetActive(true);
        station.InitializeStation();
    }

    private void OnReturnStationToPool(StationScript station)
    {
        station.gameObject.SetActive(false);
    }

    StationScript CreateStation()
    {
        var station = Instantiate(_stationPrefab);
        station.SetPool(_stationPool);
        return station;
    }
}
