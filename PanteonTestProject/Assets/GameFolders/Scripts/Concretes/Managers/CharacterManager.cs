using PanteonTestProject.Abstracts.Controllers;
using PanteonTestProject.Controllers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PanteonTestProject.Managers
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] List<EntityController> currentRaceEntities;
        [SerializeField] List<EntityController> finishRaceEntities;

        EntityController[] _entityControllers;

        [SerializeField] int _racePlace;

        public int RacePlace => _racePlace;

        private void Awake()
        {
            _entityControllers = GetComponentsInChildren<EntityController>();
        }

        private void Update()
        {
            if (!finishRaceEntities.Any(x => x is PlayerController))
            {
                currentRaceEntities = _entityControllers.
                 OrderBy(x => Vector3.Distance(x.transform.position, target.transform.position)).Where(x => !x.IsRaceFinish).ToList();

                finishRaceEntities = _entityControllers.Where(x => x.IsRaceFinish).ToList();

                _racePlace = currentRaceEntities.IndexOf(_entityControllers.FirstOrDefault(x => x is PlayerController)) + 1 + finishRaceEntities.Count;
            }
        }
    }
}

