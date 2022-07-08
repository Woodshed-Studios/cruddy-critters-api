using CruddyCrittersAPI.Models;

namespace CruddyCrittersAPI.Services;

public interface ILobbyManager
{
    Lobby CreateLobby(string roomCode, User user);
    Lobby GetLobby(string roomCode);
    void LeaveLobby(string roomCode, User user);
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
    public Lobby GetLobby(string roomCode)
    {
        return lobbies[roomCode];
    }

    /// <inheritdoc />
    public Lobby CreateLobby(string roomCode, User user)
    {
        var lobby = new Lobby(user);
        lobbies.Add(roomCode, lobby);
        return lobby;
    }

    /// <inheritdoc />
    public void LeaveLobby(string roomCode, User user)
    {
        var lobby = lobbies[roomCode];
        lobby.Users.Remove(user);

        if (lobby.Users.Count == 0)
            lobbies.Remove(roomCode);
    }

}
