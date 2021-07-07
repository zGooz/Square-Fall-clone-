
using UnityEngine;
using DG.Tweening;


public class Scaler : MonoBehaviour
{
    [SerializeField] float _duration;

    private void Awake()
    {
        var form = GetComponent<Transform>();
        var currentScale = form.localScale;
        var sequence = DOTween.Sequence();

        form.localScale = Vector2.zero;
        sequence.Append(form.DOScale(currentScale, _duration));
    }
}
