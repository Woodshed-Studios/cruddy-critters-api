using Microsoft.AspNetCore.SignalR;

namespace CruddyCrittersAPI.Hubs
{
    /// <summary>
    /// Hub that will handle communication for lobbies.
    /// </summary>
    public class LobbyHub : Hub
    {
        // TODO: How to properly divide and create lobbies?
        public async Task ChatMessage(string name, string message)
        {
            throw new NotImplementedException();
        }

        public async Task CreateLobby(string name)
        {
            throw new NotImplementedException();
        }

        public async Task JoinLobby(string name, string roomCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not sure if this is needed, SignalR can detect when a user disconnects.
        /// </summary>
        public async Task LeaveLobby()
        {
            throw new NotImplementedException();
        }
    }
}
