using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _blasting;

    private readonly int _leftKeyMouse = 0;
    private int _maxChance = 100;
    private int _minChance = 1;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftKeyMouse))
        {
            Cube cube = SelectCubeInScene();

            if (cube != null)
            {
                if (Random.Range(_minChance, _maxChance) <= cube.ChanceSeparation)
                {
                     _blasting.Explode(_spawner.Spawn(cube));
                }

                Destroy(cube.gameObject);
            }
        }
    }

    private Cube SelectCubeInScene()
    {
        Cube cube = null;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform objectHit = hit.transform;

            objectHit.TryGetComponent<Cube>(out cube);
        }

        return cube;
    }
}
