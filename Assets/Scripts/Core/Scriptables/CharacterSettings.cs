using UnityEngine;
using System;
using AFootball.Core.Units;

namespace AFootball.Core.Scriptables
{
    [CreateAssetMenu(menuName = "Character/Settings", fileName = "CharacterData")]
    public class CharacterSettings: ScriptableObject
    {
        [SerializeField] private CharacterType _type;
        [SerializeField] private Character _prefab;
        [SerializeField, Range(1f,10f)] private float _speed = 1;
        [SerializeField] private bool _isRandomSpeed = false;
        [SerializeField, Range(1f,200f)] private float _rotationSpeed = 1;
        [SerializeField, Range(0.6f,1.4f)] private float _size = 1f;

        public CharacterType Type => _type;
        public Character Prefab => _prefab;
        public float Speed => _speed;
        public bool isRandomSpeed => _isRandomSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float Size => _size;

    }        
    public enum CharacterType
             {
                 Player,
                 AI
             }
}