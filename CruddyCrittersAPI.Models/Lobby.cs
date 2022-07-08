namespace CruddyCrittersAPI.Models;
public class Lobby
{
    // TODO
    public List<User> Users {get; private set;}
    public User Host {get; private set;}
    public Games Game {get; set;}
    public GameState? GameState {get; set;}

    public Lobby(User host) {
        Users = new List<User>() { host };
        Host = host;
        GameState = null;
        Game = Games.TicTacToe;
    }
}
