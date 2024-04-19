using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private LayerMask _layerMask;

    private Ray _ray;

    private float _chanceOfSplitting = 1f;

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
                    _chanceOfSplitting = hitObject.transform.localScale.x;

                    if (Random.value <= _chanceOfSplitting)
                    {
                        _cubeSpawner.RandomSpawn(hitObject.transform);
                        cube.Explode();
                    }

                    cube.SelfDestroy(hitObject.transform);
                }
            }
        }
    }
}
