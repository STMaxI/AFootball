using System.Collections.Generic;
using AFootball.Core.Interfaces;
using AFootball.Core.ObjectsFactory;
using AFootball.Core.Scriptables;
using AFootball.Core.Units;
using UnityEngine;

namespace AFootball.Environment
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private Transform _playerSpawnPoints;
        [SerializeField] private List<Transform> _rivalSpawnPoints;

        private List<Character> _spawnedUnits = new List<Character>();

        private IStateHandler _stateHandler;


        public void Init(IStateHandler stateHandler)
        {
            _stateHandler = stateHandler;

            SpawnUnit(CharacterType.Player, new List<Transform>() {_playerSpawnPoints});
            var playerCharacter = _spawnedUnits[0];

            SpawnUnit(CharacterType.AI, _rivalSpawnPoints);
        }

        public void Respawn()
        {
            if (_spawnedUnits.Count == 0) return;

            var spawnPoints = new List<Transform>() {_playerSpawnPoints};
            spawnPoints.AddRange(_rivalSpawnPoints);

            for (int i = 0; i < _spawnedUnits.Count; i++)
            {
                _spawnedUnits[i].transform
                    .SetPositionAndRotation(spawnPoints[i].position, spawnPoints[i].transform.rotation);
            }

            Rigidbody playerRb;
            if (_spawnedUnits[0].TryGetComponent(out playerRb))
                playerRb.Sleep();
        }

        private void SpawnUnit(CharacterType characterType, List<Transform> spawnPoints)
        {
            Character unit;
            foreach (var spawnPosition in spawnPoints)
            {
                if (!_characterFactory.TryGet(characterType, out unit))
                    break;
                unit.SetStateHandler(_stateHandler);
                _spawnedUnits.Add(unit);
                unit.transform.SetPositionAndRotation(spawnPosition.position, spawnPosition.transform.rotation);
            }
        }
    }
}