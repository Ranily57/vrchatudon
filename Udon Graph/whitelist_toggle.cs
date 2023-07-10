using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class whitelist_toggle : UdonSharpBehaviour
{
    public GameObject objectToDisable;
    public string[] whitelist;

    private void Start()
    {
        if (objectToDisable == null)
        {
            Debug.LogError("Aucun object est mis");
            return;
        }

        if (whitelist == null || whitelist.Length == 0)
        {
            Debug.LogError("Personne est whitelister");
            return;
        }

        VRCPlayerApi[] players = new VRCPlayerApi[VRCPlayerApi.GetPlayerCount()];
        VRCPlayerApi.GetPlayers(players);

        for (int i = 0; i < players.Length; i++)
        {
            if (IsPlayerInWhitelist(players[i].displayName))
            {
                objectToDisable.SetActive(false);
                break;
            }
        }
    }

    private bool IsPlayerInWhitelist(string playerDisplayName)
    {
        for (int i = 0; i < whitelist.Length; i++)
        {
            if (whitelist[i] == playerDisplayName)
            {
                return true;
            }
        }

        return false;
    }
}
