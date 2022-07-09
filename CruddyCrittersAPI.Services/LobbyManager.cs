using CruddyCrittersAPI.Models;

namespace CruddyCrittersAPI.Services;

public interface ILobbyManager
{
    Lobby GetLobby(string roomCode);
    Lobby JoinLobby(string roomCode, User user);
    Lobby LeaveLobby(string roomCode, User user);
}

public class LobbyManager : ILobbyManager
{
    // TODO How do we want to store lobby information? Redis?
    // This is temporary
    IDictionary<string, Lobby> lobbies;
    public LobbyManager()
    {
        lobbies = new Dictionary<string, Lobby>();
    }

    /// <inheritdoc />
    public Lobby JoinLobby(string roomCode, User user)
    {
        if(lobbies.TryGetValue(roomCode, out var lobby)) {
           lobby.Users.Add(user);
           return lobby;
        }

        return CreateLobby(roomCode, user);
    }

    /// <inheritdoc />
    public Lobby GetLobby(string roomCode) {
        return lobbies[roomCode];
    }

    /// <summary>
    /// Create a new lobby
    /// </summary>
    private Lobby CreateLobby(string roomCode, User user)
    {
        var lobby = new Lobby(user);
        lobbies.Add(roomCode, lobby);
        return lobby;
    }

    /// <inheritdoc />
    public Lobby LeaveLobby(string roomCode, User user)
    {
        var lobby = lobbies[roomCode];
        lobby.Users.Remove(user);

        if (lobby.Users.Count == 0) {
            lobbies.Remove(roomCode);
        }

        return lobby;
    }

}
