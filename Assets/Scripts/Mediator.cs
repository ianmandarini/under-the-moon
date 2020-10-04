using System;
using System.Collections;
using Dialogue;
using Items;
using Movement;
using NPCs;
using UnityEngine;

public class Mediator: MonoBehaviour
{
    [SerializeField] private DialogueSO dialogueSO = default;
    [SerializeField] private NPCSO npcsSO = default;
    [SerializeField] private MovementSO movementSO = default;
    [SerializeField] private ItemSO itemSO = default;
    private void OnEnable()
    {
        this.dialogueSO.DialogueStarted += this.DialogueStartedEventHandler;
        this.dialogueSO.DialogueEnded += this.DialogueEndedEventHandler;
    }

    private void OnDisable()
    {
        this.dialogueSO.DialogueStarted -= this.DialogueStartedEventHandler;
        this.dialogueSO.DialogueEnded -= this.DialogueEndedEventHandler;
    }

    private void Start()
    {
        this.AllowWorldActions();
        this.itemSO.Start();
    }

    private void DialogueStartedEventHandler(object sender, EventArgs e)
    {
        this.BlockWorldActions();
    }

    private void DialogueEndedEventHandler(object sender, EventArgs e)
    {
        this.StartCoroutine(this.AllowWorldNextFrame());
    }

    private IEnumerator AllowWorldNextFrame()
    {
        yield return null;
        this.AllowWorldActions();
    }

    private void AllowWorldActions()
    {
        this.npcsSO.AllowInteractions();
        this.movementSO.AllowMovement();
        this.itemSO.AllowPickOrDropItems();
    }

    private void BlockWorldActions()
    {
        this.npcsSO.BlockInteractions();
        this.movementSO.BlockMovement();
        this.itemSO.BlockPickOrDropItems();
    }
}