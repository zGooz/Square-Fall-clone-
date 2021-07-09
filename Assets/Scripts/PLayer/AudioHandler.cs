
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Movement))]

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _soundCollideReflector;
    [SerializeField] private AudioClip _soundCollideBonus;
    [SerializeField] private AudioClip _soundCollideSquare;

    private AudioSource _audioSource;
    private Movement _movementr;
    private Keeper _keeper;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _movementr = GetComponent<Movement>();
        _keeper = GetComponent<Keeper>();
    }

    private void OnEnable()
    {
        _movementr.CollideReflector += PlayCollideReflectorSound;
        _keeper.PickUpBonusStart += PlayColliderBonusSound;
        _keeper.FaceObstacleStart += PlayColliderSquareSound;
    }

    private void OnDisable()
    {
        _movementr.CollideReflector -= PlayCollideReflectorSound;
        _keeper.PickUpBonusStart -= PlayColliderBonusSound;
        _keeper.FaceObstacleStart -= PlayColliderSquareSound;
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
