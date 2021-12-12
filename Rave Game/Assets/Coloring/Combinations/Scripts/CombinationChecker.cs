using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationChecker : MonoBehaviour
{
    [SerializeField] private List<AnimalCombination> _animalCombinations;

    public void CheckCombination(List<Paint> paints)
    {
        foreach(AnimalCombination animalCombination in _animalCombinations)
            if(animalCombination.CheckCombination(paints))
                Debug.Log(animalCombination.name);
    }
}
