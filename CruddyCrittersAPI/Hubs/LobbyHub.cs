using Microsoft.AspNetCore.SignalR;

namespace CruddyCrittersAPI.Hubs
{
    /// <summary>
    /// Hub that will handle communication for lobbies.
    /// </summary>
    public class LobbyHub : Hub
    {
        public async Task ChatMessage(string name, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// We do not need this method. When a lobby is created the host can just call 'JoinLobby' instead.
        /// </summary>
        public async Task CreateLobby(string name)
        {
            // Create lobby and add member as host
            // Generate a new lobby id
            // string base64Id = Convert.ToBase64String(new Guid().ToByteArray());
            // await Groups.AddToGroupAsync(Context.ConnectionId, base64Id);
            throw new NotImplementedException();
        }

        public async Task JoinLobby(string name, string roomCode)
        {
            // Add member to lobby
            
            await Groups.AddToGroupAsync(Context.ConnectionId, roomCode);
            await ChatMessage(name, "Joined the room!");
        }

        /// <summary>
        /// Not sure if this is needed, SignalR can detect when a user disconnects.
        /// </summary>
        public async Task LeaveLobby(string name, string roomCode)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomCode);
        }
    }
}
