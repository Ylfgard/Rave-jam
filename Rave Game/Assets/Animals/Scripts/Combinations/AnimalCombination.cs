using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCombination : MonoBehaviour
{
    [SerializeField] private Palette _palette;
    [SerializeField] private GameObject _animal;
    [SerializeField] private List<Combination> _combinations;
    private List<AnimalBehavior> _animalsBehavior = new List<AnimalBehavior>();

    public bool CheckCombination(List<Paint> paints)
    {
        foreach(Combination combination in _combinations)
            if(combination.Paints == paints)
                return true;
        return false;
    }

    public void SpawnAnimal()
    {
        if(_animalsBehavior.Count == 0)
            ShowAnimal();
        AnimalBehavior animalBehavior = Instantiate(_animal, Vector3.zero, Quaternion.identity).GetComponent<AnimalBehavior>();
        animalBehavior.Init(_palette);
        _animalsBehavior.Add(animalBehavior);
    }

    public void DespawnAnimal()
    {
        if(_animalsBehavior.Count == 0)
        {
            return;
        }
        else
        {
            _animalsBehavior[0].Despawn();
            if(_animalsBehavior.Count == 0)
                HideAnimal();
        }
    }

    private void ShowAnimal()
    {
        Debug.Log("ShowAnimal");
    }

    private void HideAnimal()
    {
        Debug.Log("HideAnimal");
    }
}
