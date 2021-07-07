
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


[RequireComponent(typeof(CircleCollider2D))]

public class Keeper : MonoBehaviour
{
    public event UnityAction Keep;
    public event UnityAction SpawnParticleOfLoser;
    public event UnityAction Fail;

    [SerializeField, Min(1.1f)] private float _scaleFactor = 1.2f;
    [SerializeField] private float _duration = 0.1f;

    private Transform _transform;
    private Vector2 _startScale;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _startScale = _transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;
        var checkBonus = other.TryGetComponent(out Bonus _);
        var checkSquare = other.TryGetComponent(out Square _);
        var sequence = DOTween.Sequence();

        if (checkBonus)
        {
            sequence.Append(_transform.DOScale(_startScale * _scaleFactor, _duration))
                    .AppendInterval(0.01f)
                    .Join(_transform.DOScale(_startScale, _duration))
                    .AppendCallback(() => Keep?.Invoke());
        }
        else if (checkSquare)
        {
            sequence.AppendCallback(() => SpawnParticleOfLoser?.Invoke())
                    .AppendInterval(0.2f)
                    .AppendCallback(() => Fail?.Invoke());
        }

        Destroy(other);
    }
}
