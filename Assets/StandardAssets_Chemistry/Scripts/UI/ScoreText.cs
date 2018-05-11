﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public Text sumText;
    public Text currentText;

    // Use this for initialization
    void Start () {
        currentText.gameObject.GetComponent<Animator>().enabled = false;
        UpdateScore();
        SlotSpawner.MolCompleted += UpdateScore;
        EmptyParentMolecule.MolConstructed += UpdateScore;
	}

    public void UpdateScore()
    {
        if (GameManager.currentLevel == GameManager.Levels.moleculeNaming)
        {
			sumText.text = MoleculeManager.instance._naming_strategy_count.ToString();
            currentText.text = GameManager.namedMolecules.ToString();
            StartCoroutine(WaitForSec());

        }
        else
        {
			sumText.text = MoleculeManager.instance._construction_strategy_count.ToString();
            currentText.text = GameManager.constructedMolecules.ToString();
            StartCoroutine(WaitForSec());
        }
		Debug.Log(sumText.text);
        
    }

    IEnumerator WaitForSec()
    {
        currentText.gameObject.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2f);
        currentText.gameObject.GetComponent<Animator>().enabled = false;
        currentText.gameObject.GetComponent<Animator>().Play("ScoreText", -1, 0f);
    }

    private void OnDisable()
    {
        SlotSpawner.MolCompleted -= UpdateScore;
        EmptyParentMolecule.MolConstructed -= UpdateScore;
    }

}
