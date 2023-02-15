using System;
using mainGame;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
   private AudioSource _audioSource;
   [Header("Sounds")]
   [SerializeField] private AudioClip _buttonClick;
   [SerializeField] private AudioClip _die;
   [SerializeField] private AudioClip _land;
   [SerializeField] private AudioClip _jump;
   [Space] 
   [Header("Event Objects")]
   [SerializeField] private PlayerController _playerController;
   [SerializeField] private UIController _UIcontroller;

   private void Start()
   {
      _audioSource = GetComponent<AudioSource>();
   }

   private void OnEnable()
   {
      _playerController.DieSound += DieSound;
      _playerController.JumpSound += JumpSound;
      _playerController.LandSound += LandSound;

      _UIcontroller.ButtonClick += ButtonClick;
   }

   private void OnDisable()
   {
      _playerController.DieSound -= DieSound;
      _playerController.JumpSound -= JumpSound;
      _playerController.LandSound -= LandSound;

      _UIcontroller.ButtonClick -= ButtonClick;  
   }

   void DieSound()
   {
      _audioSource.PlayOneShot(_die);
   }

   void JumpSound()
   {
      _audioSource.PlayOneShot(_jump);
   }

   void LandSound()
   {
      _audioSource.PlayOneShot(_land);
   }

   void ButtonClick()
   {
      _audioSource.PlayOneShot(_buttonClick);
   }
   
}
