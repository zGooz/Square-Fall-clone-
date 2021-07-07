
using UnityEngine;
using DG.Tweening;


public class Scaler : MonoBehaviour
{
    [SerializeField] private float _duration;

    private void Awake()
    {
        var form = GetComponent<Transform>();
        var sequence = DOTween.Sequence();
        var startScale = form.localScale;

        form.localScale = Vector2.zero;
        sequence.Append(form.DOScale(startScale, _duration));
    }
}
