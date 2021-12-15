using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private List<TreeLevelStage> _levelStages;
    private List<Branch> _growedBranches = new List<Branch>();
    private int _curEssenceCount;
    private int _curStageIndex;
    private TreeLevelStagesCompleteCommand _completeCommand = new TreeLevelStagesCompleteCommand();

    private void Start() 
    {
        _mediator.Subscribe<GetEssenceCommand>(GetEssence);
        foreach(TreeLevelStage levelStage in _levelStages)
            foreach(Branch branch in levelStage.Branches)
                if(levelStage != _levelStages[0])
                {
                    branch.gameObject.SetActive(false);
                }
                else
                {
                    branch.gameObject.SetActive(true);
                    _growedBranches.Add(branch);
                }
        _curStageIndex = 0;
    }

    private void GetEssence(GetEssenceCommand callback)
    {
        _curEssenceCount += callback.Count;
        if(_curEssenceCount >= _levelStages[_curStageIndex].EssenceNeed)
            ShowNextStage();
    }

    private void ShowNextStage()
    {
        _curStageIndex++;
        if(_curStageIndex >= _levelStages.Count)
        {
            _mediator.Publish(_completeCommand);
        }
        else
        {
            
            foreach(Branch branch in _levelStages[_curStageIndex].Branches)
            {
                Debug.Log("ShowThem " + branch);
                _growedBranches.Add(branch);
                branch.gameObject.SetActive(true);
            }
        }
    }
}

[Serializable]
public class TreeLevelStage 
{
    [SerializeField] private List<Branch> _branches;
    [SerializeField] private int _nextStageEssenceNeed;

    public List<Branch> Branches => _branches;

    public int EssenceNeed => _nextStageEssenceNeed;
}
