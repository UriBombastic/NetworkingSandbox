using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerSlashBros : NetworkManager
{
    public Transform spawnPoint;
    public float spawnRange = 30;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        SlashBro slashBro = player.GetComponent<SlashBro>();
        slashBro.respawnPoint = spawnPoint;
        slashBro.respawnRange = spawnRange;
        slashBro.Respawn();
    }
}
