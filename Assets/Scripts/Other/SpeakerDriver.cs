
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(AudioSource))]

public class SpeakerDriver : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    [SerializeField] private Movement _movement;
    [SerializeField] private Keeper _keeper;
    [SerializeField] private ClickHandler _onSoundButton;
    [SerializeField] private ClickHandler _offSoundButton;
    [SerializeField] private AudioClip _soundCollideReflector;
    [SerializeField] private AudioClip _soundCollideBonus;
    [SerializeField] private AudioClip _soundCollideSquare;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _movement.CollideReflector += PlayCollideReflectorSound;
        _keeper.PickUpBonusStart += PlayColliderBonusSound;
        _keeper.FaceObstacleStart += PlayColliderSquareSound;
        _onSoundButton.Click += SoundsUpVolumeToMaximum;
        _offSoundButton.Click += SoundsDownVolumeToMinimum;
    }

    private void OnDisable()
    {
        _movement.CollideReflector -= PlayCollideReflectorSound;
        _keeper.PickUpBonusStart -= PlayColliderBonusSound;
        _keeper.FaceObstacleStart -= PlayColliderSquareSound;
        _onSoundButton.Click -= SoundsUpVolumeToMaximum;
        _offSoundButton.Click -= SoundsDownVolumeToMinimum;
    }

    private void SoundsUpVolumeToMaximum()
    {
        DOTween.Sequence().Append(_audioSource.DOFade(1, _duration));
    }

    private void SoundsDownVolumeToMinimum()
    {
        DOTween.Sequence().Append(_audioSource.DOFade(0, _duration));
    }

    private void PlayColliderSquareSound()
    {
        PlaySound(_soundCollideSquare);
    }

    private void PlayColliderBonusSound()
    {
        PlaySound(_soundCollideBonus);
    }

    private void PlayCollideReflectorSound()
    {
        PlaySound(_soundCollideReflector);
    }

    private void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
