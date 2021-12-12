using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalCombination", menuName = "Animal/Combination", order = 0)]
public class AnimalCombination : ScriptableObject
{
    [SerializeField] private GameObject _animalPrefab;
    [SerializeField] private List<Combination> _combinations;
    private List<Animal> _animals = new List<Animal>();

    public bool CheckCombination(List<Paint> paints)
    {
        foreach(Combination combination in _combinations)
            if(combination.Paints == paints)
                return true;
        return false;
    }

    public void SpawnAnimal(Palette palette)
    {
        if(_animals.Count == 0)
            ShowAnimal();
        Animal animal = Instantiate(_animalPrefab, Vector3.zero, Quaternion.identity).GetComponent<Animal>();
        animal.Init(palette);
        _animals.Add(animal);
    }

    public void DespawnAnimal()
    {
        if(_animals.Count == 0)
        {
            return;
        }
        else
        {
            _animals[0].Despawn();
            if(_animals.Count == 0)
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
