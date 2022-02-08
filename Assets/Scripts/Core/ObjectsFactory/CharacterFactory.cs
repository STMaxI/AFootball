using AFootball.Core.Scriptables;
using AFootball.Core.Units;
using UnityEditor.XR;
using UnityEngine;

namespace AFootball.Core.ObjectsFactory
{
    public abstract class CharacterFactory: ObjectFactory
    {
        private Rigidbody playerRb;
        public bool TryGet(CharacterType type, out Character unit)
        {
            unit = null;
            var characterConfig  = GetCharacterConfig(type);
            Character instance = CreateObjectInstance(characterConfig.Prefab);
            
            if (instance == null)
                return false;
            
            if(type == CharacterType.Player) 
                playerRb = instance.GetComponent<Rigidbody>();
            
            instance.Init(characterConfig, playerRb);
            unit = instance;
            return true;
        }

        protected abstract CharacterSettings GetCharacterConfig(CharacterType type); 
    }
}