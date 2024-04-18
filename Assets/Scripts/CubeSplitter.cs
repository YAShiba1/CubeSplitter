using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private LayerMask _layerMask;

    private Ray _ray;

    private float chanceOfSplitting = 1.0f;

    private void Update()
    {
        TrySplit();
    }

    private void TrySplit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.TryGetComponent(out Cube cube))
                {
                    _cubeSpawner.SetCubeScale(hitObject.transform.localScale);

                    if (Random.value <= chanceOfSplitting)
                    {
                        float half = 0.5f;

                        _cubeSpawner.RandomSpawn(hitObject.transform);
                        cube.Explode();

                        chanceOfSplitting *= half;
                    }

                    cube.SelfDestroy(hitObject.transform);
                }
            }
        }
    }
}
