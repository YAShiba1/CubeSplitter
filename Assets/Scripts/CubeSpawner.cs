using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Cube _cubePrefab;

    private Vector3 _initialCubeScale;

    private void Start()
    {
        SpawnStartingCubs();

        _initialCubeScale = _cubePrefab.transform.localScale;
    }

    private void OnDisable()
    {
        _cubePrefab.transform.localScale = _initialCubeScale;
    }

    public void RandomSpawn(Transform spawnPoint)
    {
        int minimumNumberOfCubes = 2;
        int maximumNumberOfCubes = 7;

        int randomNumber = Random.Range(minimumNumberOfCubes, maximumNumberOfCubes);

        ReduceVolumeOfCube();

        for (int i = 0; i < randomNumber; i++)
        {
            CreateCube(spawnPoint);
        }
    }

    public void SetCubeScale(Vector3 scale)
    {
        _cubePrefab.transform.localScale = scale;
    }

    private void ReduceVolumeOfCube()
    {
        float half = 0.5f;

        _cubePrefab.transform.localScale *= half;
    }

    private void CreateCube(Transform spawnPoint)
    {
        Instantiate(_cubePrefab, spawnPoint.position, Quaternion.identity);
    }

    private void SpawnStartingCubs()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            CreateCube(_spawnPoints[i]);
        }
    }
}
