using System.Linq;
using AFootball.Core.Scriptables;
using UnityEngine;

namespace AFootball.Core.ObjectsFactory
{
    [CreateAssetMenu]
    class GeneralCharacterFactory : CharacterFactory
    {
        [SerializeField] private CharacterSettings[] characters;

        protected override CharacterSettings GetCharacterConfig(CharacterType type)
        {
            var _characterSettings = characters.FirstOrDefault(ch => ch.Type == type);
            
            if (_characterSettings == null) 
                Debug.Log($"CharacterSettings: there are no settings for type {type}");

            return _characterSettings;
        }
    }
}