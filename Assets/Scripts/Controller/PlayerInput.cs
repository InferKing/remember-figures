using UnityEngine;
using View;
using Zenject;
using Controller;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float _maxDistance = 50f;
    [SerializeField]
    private LayerMask _mask;

    private bool _isLockedInput = true;

    private GameLoop _loop;

    [Inject]
    private void InitGameLoop(GameLoop gameLoop)
    {
        _loop = gameLoop;
        _loop.GameStarted += OnGameStarted;
    }

    private void OnGameStarted()
    {
        _isLockedInput = false;
    }

    private void Update()
    {
        if (_isLockedInput) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _mask))
            {
                if (hit.collider != null && hit.collider.TryGetComponent(out Cell cell))
                {
                    cell.Click();
                }
            }
        }
    }
}
