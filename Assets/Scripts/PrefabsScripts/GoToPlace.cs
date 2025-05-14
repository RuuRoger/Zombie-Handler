using UnityEngine;
using UnityEngine.EventSystems;

public class GoToPlace : MonoBehaviour
{
    private GameObject _player;
    private bool _playerSelected;

    private void TouchPlace(Vector2 posicion)
    {
        //When you put a vector2, the raycasthit if detected a object wit tag "Accesible", let to the player
        //Goes to that position

        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(posicion);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Accessible"))
                _player.transform.position = hit.collider.transform.position;
        }
    }

    private void PlayerWasSelected() => _playerSelected = true;

    private void Awake()
    {
        _playerSelected = false;
    }
    private void Start() => _player = GameObject.FindGameObjectWithTag("Player");

    private void OnEnable()
    {
        UILevelManager.OnHandlerSelectedPlayer += PlayerWasSelected;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _playerSelected)
            TouchPlace(Input.mousePosition);

        if ((Input.touchCount > 0) && _playerSelected)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
                TouchPlace(touch.position);
        }
    }

}
