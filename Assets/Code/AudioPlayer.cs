using UnityEngine;

namespace RollTheBall
{
    internal sealed class AudioPlayer : IInitialization
    {
        private Initializator _initializator;
        private AudioClip _winningSound;
        private AudioClip _bonusSound;
        private AudioClip _defeatSound;
        private AudioClip _bombSound;
        private AudioSource _source;

        public AudioPlayer(Initializator initializator)
        {
            _initializator = initializator;
        }
        public void Init()
        {
            _source = References.Player.GetComponent<AudioSource>();

            //TODO: выгрузка звуков из Resources
        }

        public void PlayWinningSound()
        {
            _source.PlayOneShot(_winningSound);
        }
        public void PlayBonusSound(int value)
        {
            _source.PlayOneShot(_bonusSound, value / 20f);
        }
        public void PlayDefeatSound()
        {
            _source.PlayOneShot(_defeatSound);
        }
        public void PlayBombSound()
        {
            _source.PlayOneShot(_bombSound);
        }

        public void SubscribeToInit()
        {
            _initializator.OnInitialization += Init;
        }

        public void Dispose()
        {
            _initializator.OnInitialization -= Init;
        }
    }
}
