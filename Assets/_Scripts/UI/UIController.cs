using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text healthLabel;
    [SerializeField] private InventoryPopup popup;
    [SerializeField] private Text levelEnding;

    [System.Obsolete]
    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
    }

    [System.Obsolete]
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
    }


    private void Start()
    {
        OnHealthUpdated();

        levelEnding.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            bool isShowing = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isShowing);
            popup.Refresh();
        }
    }

    private void OnHealthUpdated()
    {
        string message = "Health: " + Managers.Player.health + " / " + Managers.Player.maxHealth;
        healthLabel.text = message;
    }

    [System.Obsolete]
    void OnLevelFailed()
    {
        StartCoroutine(FailLevel());
    }

    [System.Obsolete]
    IEnumerator FailLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Failed";

        yield return new WaitForSeconds(2);

        Managers.Player.Respawn();
        Managers.Mission.RestartCurrent();
    }

    [System.Obsolete]
    void OnLevelComplete()
    {
        StartCoroutine(CompleteLevel());

    }

    [System.Obsolete]
    private IEnumerator CompleteLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Complete";

        yield return new WaitForSeconds(2);

        Managers.Mission.GoToNext();
    }
}
