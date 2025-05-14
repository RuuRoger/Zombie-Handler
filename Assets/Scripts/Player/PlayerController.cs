using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UIElements;
using System;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static event Action<int> OnShowPlayerObject; //Goes to PlayerObjectUI
        public static event Action OnSelectedPlayer; //Goes to GoToPlace


        private int _hero;

       private void PlayerTouchHandler()
        {
            if (Input.GetMouseButtonUp(0))
                PlayerTouched(Input.mousePosition);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                    PlayerTouched(touch.position);
            }
       }

        private void PlayerTouched(Vector2 player)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(player);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                
                if (hit.collider.CompareTag("Player"))
                {
                    OnShowPlayerObject?.Invoke(_hero);
                    OnSelectedPlayer?.Invoke();

                }
            }
        }

        private void Awake()
        {
            _hero = 0;
        }
        private void Update()
        { 
            PlayerTouchHandler();
            
        } 

    }
}
