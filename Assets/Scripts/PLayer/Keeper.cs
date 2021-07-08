
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


[RequireComponent(typeof(CircleCollider2D))]

public class Keeper : MonoBehaviour
{
    public event UnityAction PickUpBonus;
    public event UnityAction SpawnParticleOfLoser;
    public event UnityAction FaceObstacle;
    public event UnityAction MakeStop;

    private bool IsCollisionHandled { get; set; } = true;

    [SerializeField, Min(1.1f)] private float _scaleFactor = 1.2f;
    [SerializeField] private float _duration = 0.1f;
    [SerializeField] private float _interval = 1f;

    private Transform _transform;
    private Vector3 _startScale;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _startScale = _transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsCollisionHandled)
        {
            return;
        }

        IsCollisionHandled = false;

        var other = collision.gameObject;
        var checkBonus = other.TryGetComponent(out Bonus _);
        var checkSquare = other.TryGetComponent(out Square _);
        var playerSequence = DOTween.Sequence();

        if (checkBonus)
        {
            playerSequence.Append(_transform.DOScale(_startScale * _scaleFactor, _duration))
                .AppendInterval(_interval)
                .Join(_transform.DOScale(_startScale, _duration))
                .AppendInterval(_interval)
                .AppendCallback(() => PickUpBonus?.Invoke());
        }
        else if (checkSquare)
        {
            playerSequence.AppendCallback(() => SpawnParticleOfLoser?.Invoke())
                .AppendCallback(() => MakeStop?.Invoke())
                .AppendInterval(_interval)
                .AppendCallback(() => FaceObstacle?.Invoke());
        }

        playerSequence.AppendCallback(() => IsCollisionHandled = true);
    }
}
