using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private Essence _essence;
    [SerializeField] private List<TreeLevelStage> _levelStages;
    private List<GameObject> _growedBranches = new List<GameObject>();
    private int _curStageIndex;
    private bool _growed;
    private TreeLevelStagesCompleteCommand _completeCommand = new TreeLevelStagesCompleteCommand();

    private void Start() 
    {
        _mediator.Subscribe<GetEssenceCommand>(GetEssence);
        foreach(TreeLevelStage levelStage in _levelStages)
            foreach(GameObject branch in levelStage.Branches)
                if(levelStage != _levelStages[0])
                {
                    branch.SetActive(false);
                }
                else
                {
                    branch.SetActive(true);
                    _growedBranches.Add(branch);
                }
        _curStageIndex = 0;
        _growed = false;
    }

    private void GetEssence(GetEssenceCommand callback)
    {
        if(_growed == false)
        {
            _essence.AddCount(callback.Count);
            if(_essence.Count >= _levelStages[_curStageIndex].EssenceNeed)
                ShowNextStage();
        }
    }

    private void ShowNextStage()
    {
        _curStageIndex++;
        if(_curStageIndex >= _levelStages.Count)
        {
            _mediator.Publish(_completeCommand);
            _growed = true;
        }
        else
        {
            foreach(GameObject branch in _levelStages[_curStageIndex].Branches)
            {
                _growedBranches.Add(branch);
                branch.SetActive(true);
            }
        }
    }
}

[Serializable]
public class TreeLevelStage 
{
    [SerializeField] private List<GameObject> _branches;
    [SerializeField] private int _nextStageEssenceNeed;

    public List<GameObject> Branches => _branches;

    public int EssenceNeed => _nextStageEssenceNeed;
}
