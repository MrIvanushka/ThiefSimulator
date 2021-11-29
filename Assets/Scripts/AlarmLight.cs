using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class AlarmLight : MonoBehaviour
{
    [SerializeField] private Light _redLight;
    [SerializeField] private AudioSource _audioPlayer;
    [SerializeField] private float _maxLightIntensity;
    [SerializeField] private float _blinkDuration;

    private bool _isWorking = false;

    private void Start()
    {
        _audioPlayer = GetComponent<AudioSource>();
    }

    public void StartBlinking()
    {
        if (_isWorking == false)
        {
            _audioPlayer.DOFade(1, _blinkDuration).SetLoops(-1, LoopType.Yoyo);
            _redLight.DOIntensity(_maxLightIntensity, _blinkDuration).SetLoops(-1, LoopType.Yoyo);
            _isWorking = true;
        }
    }
}
