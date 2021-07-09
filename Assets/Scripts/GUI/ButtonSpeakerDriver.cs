
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ClickHandler))]

public class ButtonSpeakerDriver : MonoBehaviour
{
    private bool IsClicked { get; set; } = false;

    [SerializeField] private float _duration = 1f;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private ClickHandler _onSoundButton;
    [SerializeField] private ClickHandler _offSoundButton;

    private AudioSource _audioSource;
    private ClickHandler _handler;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _handler = GetComponent<ClickHandler>();
    }

    private void OnEnable()
    {
        _onSoundButton.Click += SoundsUpVolumeToMaximum;
        _offSoundButton.Click += SoundsDownVolumeToMinimum;
        _handler.Click += PlayClick;
    }

    private void OnDisable()
    {
        _onSoundButton.Click -= SoundsUpVolumeToMaximum;
        _offSoundButton.Click -= SoundsDownVolumeToMinimum;
        _handler.Click -= PlayClick;
    }

    private void SoundsUpVolumeToMaximum()
    {
        DOTween.Sequence().Append(_audioSource.DOFade(1, _duration));
    }

    private void SoundsDownVolumeToMinimum()
    {
        DOTween.Sequence().Append(_audioSource.DOFade(0, _duration));
    }

    private void PlayClick()
    {
        if (IsClicked)
        {
            return;
        }

        _audioSource.clip = _clip;

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        IsClicked = true;
    }
}
