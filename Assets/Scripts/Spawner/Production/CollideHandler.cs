
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


public class CollideHandler : MonoBehaviour
{
    public event UnityAction CollideComplete;

    [SerializeField] private float _duration;
    [SerializeField] private float _interval;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;

        if (other.TryGetComponent(out Player _))
        {
            CollideComplete?.Invoke();

            var obstacleSequence = DOTween.Sequence();

            obstacleSequence.Append(_transform.DOScale(0, _duration))
                .AppendInterval(_interval)
                .AppendCallback(() => Destroy(gameObject));
        }
    }
}
