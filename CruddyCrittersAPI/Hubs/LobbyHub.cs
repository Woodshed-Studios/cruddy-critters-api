using CruddyCrittersAPI.Models;
using CruddyCrittersAPI.Services;
using Microsoft.AspNetCore.SignalR;

namespace CruddyCrittersAPI.Hubs
{
    /// <summary>
    /// Hub that will handle communication for lobbies.
    /// </summary>
    public class LobbyHub : Hub
    {
        private readonly ILobbyManager lobbyManager;
        private const string RecieveMessage = "ReceiveMessage";
        private const string UpdateLobby = "UpdateLobby";

        public LobbyHub(ILobbyManager lobbyManager) {
            this.lobbyManager = lobbyManager;
        }

        ///<summary>
        /// Send a chat message to your lobby
        ///</summary>
        public async Task ChatMessage(string roomCode, string name, string message)
            => await Clients.Group(roomCode).SendAsync("ReceiveMessage", name, message);

        public async Task JoinLobby(string roomCode, string name)
        {
            // Add member to lobby
            await Groups.AddToGroupAsync(Context.ConnectionId, roomCode);
            // TODO we will need some storage of user properties to avoid building the object over and over
            var user = new User(){Name = name};
            var lobby = lobbyManager.JoinLobby(roomCode, user);
            await ChatMessage(roomCode, name, "Joined the room!");
            await Clients.Group(roomCode).SendAsync(UpdateLobby, lobby);
        }

        /// <summary>
        /// Not sure if this is needed, SignalR can detect when a user disconnects.
        /// </summary>
        public async Task LeaveLobby(string roomCode, string name)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomCode);
            var user = new User(){Name = name};
            var lobby = lobbyManager.LeaveLobby(roomCode, user);
            await ChatMessage(roomCode, name, "Left the room!");
            await Clients.Group(roomCode).SendAsync(UpdateLobby, lobby);
        }
    }
}
