using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CombinationBook
{
    public class AnimalLine : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private CombinationSpawner combinationSpawner;
        [SerializeField] private Image _animalImage;
        [SerializeField] private TextMeshProUGUI _animalName;
        [SerializeField] private Image _animalIncomeImg;
        [SerializeField] private Sprite _essenceSprite;
        [SerializeField] private TextMeshProUGUI _animalIncomeCount;

        public void Initialize(Transform parent, AnimalData data, AnimalBehavior behavior)
        {
            _transform.SetParent(parent);
            _animalImage.sprite = behavior.BookSprite;
            _animalName.text = data.Name;
            string income = behavior.Income.ToString() + " per\n";
            income += behavior.Period.ToString() + " day(s)";
            _animalIncomeCount.text = income;
            if(behavior.BringEssence)
                _animalIncomeImg.sprite = _essenceSprite;
            else
                _animalIncomeImg.color = behavior.Paint.Color;
            combinationSpawner.SpawnCombinations(data.AnimalCombination.Combinations);
        }
    }
}
