using System;
using ChessController;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ChessService
    {
        Dictionary<string, Game> games;
        public ChessService()
        {
            games = new Dictionary<string, Game>();
        }

        public string CreateGame(string hostID)
        {
            Game game = new Game(hostID);
            games.Add(game.GameID, game);
            return game.GameID;
        }

        public void AddGuest(string gameID, string guestID)
        {
            games[gameID].GuestID = guestID;
        }

        public string Move(string gameID, Move move)
        {
            return games[gameID].Move(move);
        }

        public bool CheckMove(string gameID, string moverID, Move move)
        {
            return games[gameID].CheckMove(moverID, move);
        }
    }
}
