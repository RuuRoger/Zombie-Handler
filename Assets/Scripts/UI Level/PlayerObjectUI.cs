using DG.Tweening;
using TMPro;
using UnityEngine;

    public class PlayerObjectUI : MonoBehaviour
    {
        [SerializeField] Sprite _heroSprite;
        [SerializeField] float _axisXPosition;
        private SpriteRenderer _spriteRender;
        private  Vector3 _objetcPlayerPosition;
        private  Vector3 _targetPosition;

        private void ActivePlayerUIObject(int value)
        {
        if (value == 0)
        {
            _spriteRender.sprite = _heroSprite;
            _spriteRender.enabled = true;
            transform.DOMove(_targetPosition, 0.5f).SetEase(Ease.OutQuad);
        }
        else
            Debug.Log("Falla delegado");
        }


    private void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        _targetPosition = transform.position;
        transform.position = _targetPosition + new Vector3(_axisXPosition, 0f, 0f);

    }

        private void OnEnable()
        {
            UILevelManager.OnActivePlayerObject += ActivePlayerUIObject;
        }
    }
