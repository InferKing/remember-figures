using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private LayerMask _mask;
    [SerializeField]
    private float _maxDistance = 50f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxDistance, _mask))
            {
                if (hit.collider != null)
                {
                    // do smth...
                }
            }
        }
    }
}
