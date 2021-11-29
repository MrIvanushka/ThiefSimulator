using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class AlarmLight : MonoBehaviour
{
    [SerializeField] private Light _redLight;
    [SerializeField] private AudioSource _audioPlayer;
    [SerializeField] private float _maxLightIntensity;
    [SerializeField] private float _blinkDuration;

    private Stack<Tween> _allTweens = new Stack<Tween>();

    private void Start()
    {
        _audioPlayer = GetComponent<AudioSource>();
    }

    public void StartBlinking()
    {
        if (_allTweens.Count == 0)
        {
            _allTweens.Push(_audioPlayer.DOFade(1, _blinkDuration).SetLoops(-1, LoopType.Yoyo));
            _allTweens.Push(_redLight.DOIntensity(_maxLightIntensity, _blinkDuration).SetLoops(-1, LoopType.Yoyo));
        }
    }

    public void StopBlinking()
    {
        while(_allTweens.Count > 0)
        {
            Tween tween = _allTweens.Pop();
            tween.Kill();
        }
        _redLight.DOIntensity(0, _blinkDuration);
        _audioPlayer.DOFade(0, _blinkDuration);
    }
}
